package com.klarna.rest;

import java.io.*;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.net.*;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.Set;

import javax.ws.rs.core.MediaType;

public class HttpUrlConnectionTransport implements Transport {

    public static int DEFAULT_TIMEOUT = 30000;

    protected URI baseUri;
    protected String merchantId;
    protected String sharedSecret;

    protected String userAgent;

    // Proxy settings
    protected Proxy proxy;
    protected Authenticator proxyAuth;

    public HttpUrlConnectionTransport(final String merchantId,
                                      final String sharedSecret,
                                      final URI baseUri) {
        this.baseUri = baseUri;
        this.merchantId = merchantId;
        this.sharedSecret = sharedSecret;

        this.userAgent = Transport.USER_AGENT + "_" + Transport.VERSION;

        HttpUrlConnectionTransport.allowMethods("PATCH"); // Workaround for PATCH method
    }

    public ApiResponse get(final String path) throws
            ApiException, ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path);
        conn.setRequestMethod("GET");

        return this.processConnection(conn);
    }

    public ApiResponse post(final String path, final byte[] data) throws
            ApiException, ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path);
        conn.setRequestMethod("POST");
        setBodyPayout(conn, data);

        return this.processConnection(conn);
    }

    public ApiResponse put(final String path, final byte[] data) throws
            ApiException, ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path);
        conn.setRequestMethod("PUT");
        setBodyPayout(conn, data);

        return this.processConnection(conn);
    }

    public ApiResponse patch(final String path, final byte[] data) throws
            ApiException, ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path);
        conn.setRequestMethod("PATCH");
        setBodyPayout(conn, data);

        return this.processConnection(conn);
    }

    public ApiResponse delete(final String path) throws
            ApiException, ProtocolException, ContentTypeException, IOException {
        HttpURLConnection conn = this.buildConnection(path);
        conn.setRequestMethod("DELETE");

        return this.processConnection(conn);
    }

    public String getUserAgent() {
        return this.userAgent;
    }

    public HttpUrlConnectionTransport setUserAgent(String userAgent) {
        this.userAgent = userAgent;

        return this;
    }

    public void setProxy(final Proxy.Type scheme, final String host, final int port) {
        this.proxy = new Proxy(scheme, new InetSocketAddress(host, port));
    }

    public void setProxy(final Proxy.Type scheme, final String host, final int port, final String username, final String password) {
        this.setProxy(scheme, host, port);
        this.proxyAuth = new Authenticator() {
            public PasswordAuthentication getPasswordAuthentication() {
                return (new PasswordAuthentication(username,
                        password.toCharArray()));
            }
        };
        Authenticator.setDefault(this.proxyAuth);
    }

    protected URL buildPath(String path) throws MalformedURLException {
        URI uri = this.baseUri;
        String newPath = uri.getPath() + path;
        uri = uri.resolve(newPath);
        return uri.toURL();
    }

    protected HttpURLConnection buildConnection(String path) throws IOException {
        URL url = this.buildPath(path);

        HttpURLConnection conn;
        if (this.proxy != null) {
            conn = (HttpURLConnection) url.openConnection(this.proxy);
        } else {
            conn = (HttpURLConnection) url.openConnection();
        }

        conn.setRequestProperty("Content-Type", MediaType.APPLICATION_JSON);
        conn.setRequestProperty("User-Agent", this.userAgent);
        conn.setConnectTimeout(DEFAULT_TIMEOUT);
        conn.setReadTimeout(DEFAULT_TIMEOUT);

        setBase64Auth(conn, this.merchantId, this.sharedSecret);

        return conn;
    }

    protected void setBase64Auth(HttpURLConnection conn, String username, String password) throws IOException {
        byte[] message = (username + ":" + password).getBytes("UTF-8");
        String encoded = javax.xml.bind.DatatypeConverter.printBase64Binary(message);

        conn.setRequestProperty("Authorization", "Basic " + encoded);
    }

    protected ApiResponse processConnection(HttpURLConnection conn) throws IOException {

        ApiResponse response = new ApiResponse();

        response.setStatus(conn.getResponseCode());
        response.setHeaders(conn.getHeaderFields());

        InputStream is;
        if (response.isSuccessfull()) {
            is = conn.getInputStream();
        } else {
            is = conn.getErrorStream();
        }

        if (is != null) {
            BufferedReader in = new BufferedReader(new InputStreamReader(is));
            String inputLine;
            StringBuilder content = new StringBuilder();
            while ((inputLine = in.readLine()) != null) {
                content.append(inputLine);
            }
            in.close();

            response.setBody(content.toString());
        }

        return response;
    }

    protected void setBodyPayout(HttpURLConnection conn, byte[] data) throws IOException {
        if (data != null) {
            conn.setDoOutput(true);

            OutputStream os = conn.getOutputStream();
            os.write(data);
            os.close();
        }
    }

    private static void allowMethods(String... methods) {
        try {
            Field methodsField = HttpURLConnection.class.getDeclaredField("methods");

            Field modifiersField = Field.class.getDeclaredField("modifiers");
            modifiersField.setAccessible(true);
            modifiersField.setInt(methodsField, methodsField.getModifiers() & ~Modifier.FINAL);

            methodsField.setAccessible(true);

            String[] oldMethods = (String[]) methodsField.get(null);
            Set<String> methodsSet = new LinkedHashSet<>(Arrays.asList(oldMethods));
            methodsSet.addAll(Arrays.asList(methods));
            String[] newMethods = methodsSet.toArray(new String[0]);

            methodsField.set(null/*static field*/, newMethods);
        } catch (NoSuchFieldException | IllegalAccessException e) {
            System.out.println(e);
        }
    }
}
