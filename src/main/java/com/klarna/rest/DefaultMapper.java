package com.klarna.rest;

import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.Serializable;

public class DefaultMapper extends ObjectMapper {
    public DefaultMapper() {
        this.findAndRegisterModules();
        this.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
    }
}
