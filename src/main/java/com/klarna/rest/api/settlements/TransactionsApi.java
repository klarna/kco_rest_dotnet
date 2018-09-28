package com.klarna.rest.api.settlements;

import com.klarna.rest.*;
import com.klarna.rest.api.BaseApi;
import com.klarna.rest.model.settlements.PayoutCollection;
import com.klarna.rest.model.settlements.Transaction;
import com.klarna.rest.model.settlements.TransactionCollection;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.util.Map;

public class TransactionsApi extends BaseApi {
    protected String PATH = "/settlements/v1/transactions";

    public TransactionsApi(final Transport transport) {
        super(transport);
    }

    public TransactionCollection getTransactions(Map<String, String> urlParams)
        throws ApiException, ProtocolException, ContentTypeException, IOException {
        final ApiResponse response = this.get(PATH + "?" + this.buildQueryString(urlParams));
        response.validator()
                .expectStatusCode(Response.Status.OK)
                .expectContentType(MediaType.APPLICATION_JSON);

        return objectMapper.readValue(response.getBody(), TransactionCollection.class);
    }
}
