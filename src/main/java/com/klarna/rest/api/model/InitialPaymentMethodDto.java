/*
 * Copyright 2014 Klarna AB
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.klarna.rest.api.model;

/**
 * InitialPaymentMethodDto
 */
public class InitialPaymentMethodDto {
    /**
     * The type of the initial payment method.
     */
    public enum TypeEnum {
        INVOICE("INVOICE"),

        FIXED_AMOUNT("FIXED_AMOUNT"),

        ACCOUNT("ACCOUNT"),

        DIRECT_DEBIT("DIRECT_DEBIT"),

        CARD("CARD"),

        BANK_TRANSFER("BANK_TRANSFER"),

        PAY_IN_X("PAY_IN_X"),

        INVOICE_BUSINESS("INVOICE_BUSINESS"),

        DEFERRED_INTEREST("DEFERRED_INTEREST"),

        OTHER("OTHER");

        private String value;

        TypeEnum(String value) {
            this.value = value;
        }

        public String getValue() {
            return value;
        }

        @Override
        public String toString() {
            return String.valueOf(value);
        }

        public static TypeEnum fromValue(String text) {
            for (TypeEnum b : TypeEnum.values()) {
                if (String.valueOf(b.value).equals(text)) {
                    return b;
                }
            }
            return null;
        }
    }

    /**
     * The type of the initial payment method.
     */
    private TypeEnum type = null;

    /**
     * The description of the initial payment method.
     */
    private String description = null;

    /**
     * Gets the type of the initial payment method.
     *
     * @return Payment method type
     **/
    public TypeEnum getType() {
        return this.type;
    }

    /**
     * Sets the type of the initial payment method.
     *
     * @param type Payment type
     * @return Same instance
     */
    public InitialPaymentMethodDto setType(TypeEnum type) {
        this.type = type;
        return this;
    }

    /**
     * Gets the description of the initial payment method.
     *
     * @return description
     **/
    public String getDescription() {
        return this.description;
    }

    /**
     * Sets the description of the initial payment method.
     *
     * @param description Payment method description
     * @return Same instance
     */
    public InitialPaymentMethodDto setDescription(String description) {
        this.description = description;

        return this;
    }
}
