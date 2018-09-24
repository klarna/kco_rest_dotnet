package com.klarna.rest.api;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.klarna.rest.Transport;

public abstract class BaseApi {
    protected Transport transport;
    protected ObjectMapper objectMapper;

    public BaseApi(Transport transport) {
        this.transport = transport;
        this.objectMapper = new ObjectMapper();
    }

    public void setObjectMapper(ObjectMapper objectMapper) {
        this.objectMapper = objectMapper;
    }
}
