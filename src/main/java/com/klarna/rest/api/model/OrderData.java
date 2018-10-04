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

import org.joda.time.DateTime;

import java.util.Collections;
import java.util.List;

/**
 * Order resource data model.
 */
public class OrderData extends Model {

    /**
     * Order id.
     */
    private String orderId;

    /**
     * Order status.
     */
    private String status;

    /**
     * Fraud status.
     */
    private String fraudStatus;

    /**
     * The total amount for this order.
     */
    private Long orderAmount;

    /**
     * The original amount for this order.
     */
    private Long originalOrderAmount;

    /**
     * The total amount of all captures.
     */
    private Long capturedAmount;

    /**
     * The total amount refunded for this order.
     */
    private Long refundedAmount;

    /**
     * The remaining authorized amount for this order.
     */
    private Long remainingAuthorizedAmount;

    /**
     * Purchase currency.
     */
    private String purchaseCurrency;

    /**
     * Purchase country.
     */
    private String purchaseCountry;

    /**
     * Customers locale.
     */
    private String locale;

    /**
     * The applicable order lines.
     */
    private List<OrderLine> orderLines;

    /**
     * First merchant reference.
     */
    private String merchantReference1;

    /**
     * Second merchant reference.
     */
    private String merchantReference2;

    /**
     * Customer friendly id.
     */
    private String klarnaReference;

    /**
     * Information about the liable customer of the order.
     */
    private Customer customer;

    /**
     * Billing address.
     */
    private Address billingAddress;

    /**
     * Shipping address.
     */
    private Address shippingAddress;

    /**
     * Purchase time.
     */
    private DateTime createdAt;

    /**
     * Authorization expiration time.
     */
    private DateTime expiresAt;

    /**
     * The captures for this order.
     */
    private List<CaptureData> captures;

    /**
     * The refunds for this order.
     */
    private List<Refund> refunds;

    /**
     * Order metadata.
     */
    private String merchantData;

    /**
     * Initial payment method for this order.
     */
    private InitialPaymentMethodDto initialPaymentMethod;


    /**
     * Gets the order id.
     *
     * @return Order id
     */
    public String getOrderId() {
        return this.orderId;
    }

    /**
     * Gets the order status.
     *
     * AUTHORIZED : No captures have been made on the order.
     * PART_CAPTURED : At least one capture has been made on the order with
     *      a total captured value lower than the current total order amount.
     * CAPTURED : At least one capture has been made on the order and the
     *      total captured amount is equal to the current total order amount.
     * CANCELLED : The order is cancelled prior to making any captures.
     * EXPIRED : The authorization time expired for the order and no captures
     *      have been made.
     * CLOSED : The order is closed and no further modifications are possible.
     *
     * @return Status
     */
    public String getStatus() {
        return this.status;
    }

    /**
     * Gets the order fraud status.
     *
     * Either ACCEPTED, PENDING or REJECTED.
     *
     * @return Fraud status
     */
    public String getFraudStatus() {
        return this.fraudStatus;
    }

    /**
     * Gets the order amount.
     *
     * @return Total order amount in cents, e.g. 2500 is 25.00
     */
    public Long getOrderAmount() {
        return this.orderAmount;
    }

    /**
     * Gets the original total order amount.
     *
     * @return Total order amount in cents, e.g. 2500 is 25.00
     */
    public Long getOriginalOrderAmount() {
        return this.originalOrderAmount;
    }

    /**
     * Gets the total amount of captures for this order.
     *
     * @return Captured amount in cents, e.g. 2500 is 25.00
     */
    public Long getCapturedAmount() {
        return this.capturedAmount;
    }

    /**
     * Gets the total amount of refunds for this order.
     *
     * @return Refunded amount in cents, e.g. 2500 is 25.00
     */
    public Long getRefundedAmount() {
        return this.refundedAmount;
    }

    /**
     * Gets the remaining authorized amount.
     *
     * @return Remaining authorized amount in cents, e.g. 2500 is 25.00
     */
    public Long getRemainingAuthorizedAmount() {
        return this.remainingAuthorizedAmount;
    }

    /**
     * Gets the purchase currency.
     *
     * @return The currency (ISO 4217), e.g. "gbp"
     */
    public String getPurchaseCurrency() {
        return this.purchaseCurrency;
    }

    /**
     * Gets the purchase country.
     *
     * @return The country (ISO 3166-1 alpha-2), e.g. "gb"
     */
    public String getPurchaseCountry() {
        return this.purchaseCountry;
    }

    /**
     * Gets the customers locale.
     *
     * @return The locale (RFC1766), e.g. "en-gb"
     */
    public String getLocale() {
        return this.locale;
    }

    /**
     * Gets the order lines.
     *
     * @return Order lines
     */
    public List<OrderLine> getOrderLines() {
        return this.orderLines;
    }

    /**
     * Gets the first merchant reference.
     *
     * @return Merchant reference
     */
    public String getMerchantReference1() {
        return this.merchantReference1;
    }

    /**
     * Gets the second merchant reference.
     *
     * @return Merchant reference
     */
    public String getMerchantReference2() {
        return this.merchantReference2;
    }

    /**
     * Gets the Klarna reference.
     *
     * @return Customer friendly order id
     */
    public String getKlarnaReference() {
        return this.klarnaReference;
    }

    /**
     * Gets the customer information.
     *
     * @return Customer info
     */
    public Customer getCustomer() {
        return this.customer;
    }

    /**
     * Gets the billing address.
     *
     * @return Address
     */
    public Address getBillingAddress() {
        return this.billingAddress;
    }

    /**
     * Gets the shipping address.
     *
     * @return Address
     */
    public Address getShippingAddress() {
        return this.shippingAddress;
    }

    /**
     * Gets the purchase time.
     *
     * @return Creation time
     */
    public DateTime getCreatedAt() {
        return this.createdAt;
    }

    /**
     * Gets the authorization expiration time.
     *
     * @return Expiration time
     */
    public DateTime getExpiresAt() {
        return this.expiresAt;
    }

    /**
     * Gets the captures for this order.
     *
     * @return Read only list of captures
     */
    public List<CaptureData> getCaptures() {
        if (this.captures == null) {
            return null;
        }

        return Collections.unmodifiableList(this.captures);
    }

    /**
     * Gets the refunds for this order.
     *
     * @return Read only list of refunds
     */
    public List<Refund> getRefunds() {
        if (this.refunds == null) {
            return null;
        }

        return Collections.unmodifiableList(this.refunds);
    }

    /**
     * Gets order metadata.
     *
     * @return merchantData
     **/
    public String getMerchantData() {
        return this.merchantData;
    }

    /**
     * Gets initial payment method for the order.
     *
     * @return Initial payment method
     */
    public InitialPaymentMethodDto getInitialPaymentMethod() {
        return this.initialPaymentMethod;
    }
}
