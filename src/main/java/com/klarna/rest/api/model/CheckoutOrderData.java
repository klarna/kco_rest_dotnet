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

import com.klarna.rest.api.CheckoutOrder;
import org.codehaus.jackson.annotate.JsonIgnore;
import org.codehaus.jackson.annotate.JsonProperty;
import org.joda.time.DateTime;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

/**
 * Checkout order resource data model.
 */
public class CheckoutOrderData extends Model {

    /**
     * Unique order id.
     */
    private String orderId;

    /**
     * The merchant name.
     */
    private String name;

    /**
     * Purchase country.
     */
    private String purchaseCountry;

    /**
     * Purchase currency.
     */
    private String purchaseCurrency;

    /**
     * Customer's locale.
     */
    private String locale;

    /**
     * Current order status.
     */
    private String status;

    /**
     * Customer billing address.
     */
    private Address billingAddress;

    /**
     * Customer shipping address.
     */
    private Address shippingAddress;

    /**
     * Total amount of the order including tax and discounts.
     */
    private Long orderAmount;

    /**
     * Total tax amount of the order.
     */
    private Long orderTaxAmount;

    /**
     * Information about the orders liable customer.
     */
    private Customer customer;

    /**
     * Various URLs for the merchants store.
     */
    private MerchantUrls merchantUrls;

    /**
     * HTML snippet used to render the checkout.
     */
    private String htmlSnippet;

    /**
     * Merchant order reference.
     */
    private String merchantReference1;

    /**
     * Merchant order reference.
     */
    private String merchantReference2;

    /**
     * When the merchant created the order.
     */
    private DateTime startedAt;

    /**
     * When the customer completed the order.
     */
    private DateTime completedAt;

    /**
     * When the order was last modified.
     */
    private DateTime lastModifiedAt;

    /**
     * The customers cart.
     */
    private List<OrderLine> orderLines;

    /**
     * Various checkout options.
     */
    private CheckoutOptions options;

    /**
     * GUI options.
     */
    private Gui gui;

    /**
     * Checkout order attachment.
     */
    private Attachment attachment;

    /**
     * List of external payment methods.
     */
    private List<ExternalPaymentMethod> externalPaymentMethods;

    /**
     * List of external checkouts.
     */
    private List<ExternalCheckout> externalCheckouts;

    /**
     * A list of countries (ISO 3166 alpha-2). Default is purchase_country only.
     */
    private List<String> shippingCountries = null;

    /**
     * A list of shipping options available for this order.
     */
    private List<ShippingOption> shippingOptions = null;

    /**
     * Pass through field.
     */
    private String merchantData = null;

    /**
     * Stores merchant requested data.
     */
    private MerchantRequested merchantRequested = null;

    /**
     * Current shipping options selected by the customer.
     */
    private ShippingOption selectedShippingOption = null;

    /**
     * Indicates whether this purchase will create a token that can be used by the merchant
     * to create recurring purchases. This must be enabled for the merchant to use.
     */
    private Boolean recurring = false;

    /**
     * Token to be used when creating recurring orders.
     */
    private String recurringToken = null;

    /**
     * Description recurring subscription.
     */
    private String recurringDescription = null;


    /**
     * Gets the order id.
     *
     * @return Order id
     */
    public String getOrderId() {
        return this.orderId;
    }

    /**
     * Gets the merchant name.
     *
     * @return Merchant name
     */
    public String getName() {
        return this.name;
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
     * Sets the purchase country.
     *
     * @param country The country (ISO 3166-1 alpha-2), e.g. "gb"
     * @return Same instance
     */
    public CheckoutOrderData setPurchaseCountry(final String country) {
        this.purchaseCountry = country;

        return this;
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
     * Sets the purchase currency.
     *
     * @param currency The currency (ISO 4217), e.g. "gbp"
     * @return Same instance
     */
    public CheckoutOrderData setPurchaseCurrency(final String currency) {
        this.purchaseCurrency = currency;

        return this;
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
     * Sets the customers locale.
     *
     * @param locale The locale (RFC1766), e.g. "en-gb"
     * @return Same instance
     */
    @JsonProperty
    public CheckoutOrderData setLocale(final String locale) {
        this.locale = locale;

        return this;
    }

    /**
     * Sets the customers locale.
     *
     * @param locale Customers locale
     * @return Same instance
     */
    @JsonIgnore
    public CheckoutOrderData setLocale(final Locale locale) {
        this.locale = locale.toLanguageTag().toLowerCase();

        return this;
    }

    /**
     * Gets the order status.
     *
     * checkout_incomplete : Purchase is not yet completed.
     * checkout_complete : Customer has completed the purchase.
     *
     * @return Order status
     */
    public String getStatus() {
        return status;
    }

    /**
     * Gets the billing address.
     *
     * @return Billing address
     */
    public Address getBillingAddress() {
        return this.billingAddress;
    }

    /**
     * Sets the billing address.
     *
     * @param address Billing address
     * @return Same instance
     */
    public CheckoutOrderData setBillingAddress(final Address address) {
        this.billingAddress = address;

        return this;
    }

    /**
     * Gets the shipping address.
     *
     * @return Shipping address
     */
    public Address getShippingAddress() {
        return this.shippingAddress;
    }

    /**
     * Sets the shipping address.
     *
     * @param address Shipping address
     * @return Same instance
     */
    public CheckoutOrderData setShippingAddress(final Address address) {
        this.shippingAddress = address;

        return this;
    }

    /**
     * Gets the total order amount, including tax and discounts.
     *
     * @return Order amount
     */
    public Long getOrderAmount() {
        return this.orderAmount;
    }

    /**
     * Sets the total order amount, including tax and discounts.
     *
     * @param amount Order amount
     * @return Same instance
     */
    public CheckoutOrderData setOrderAmount(final Long amount) {
        this.orderAmount = amount;

        return this;
    }

    /**
     * Gets the total tax amount of the order.
     *
     * @return Tax amount
     */
    public Long getOrderTaxAmount() {
        return this.orderTaxAmount;
    }

    /**
     * Sets the total tax amount of the order.
     *
     * @param amount Tax amount
     * @return Same instance
     */
    public CheckoutOrderData setOrderTaxAmount(final Long amount) {
        this.orderTaxAmount = amount;

        return this;
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
     * Sets the order lines.
     *
     * @param lines Order lines
     * @return Same instance
     */
    public CheckoutOrderData setOrderLines(final List<OrderLine> lines) {
        this.orderLines = lines;

        return this;
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
     * Sets the customer information.
     *
     * @param customer Customer info
     * @return Same instance
     */
    public CheckoutOrderData setCustomer(final Customer customer) {
        this.customer = customer;

        return this;
    }

    /**
     * Gets the merchant URLs.
     *
     * @return Merchant URLs
     */
    public MerchantUrls getMerchantUrls() {
        return this.merchantUrls;
    }

    /**
     * Sets the merchant URLs.
     *
     * @param merchantUrls Merchant URLs
     * @return Same instance
     */
    public CheckoutOrderData setMerchantUrls(final MerchantUrls merchantUrls) {
        this.merchantUrls = merchantUrls;

        return this;
    }

    /**
     * Gets the checkout HTML snippet.
     *
     * @return HTML snippet
     */
    public String getHtmlSnippet() {
        return this.htmlSnippet;
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
     * Sets the first merchant reference.
     *
     * @param reference Merchant reference
     * @return Same instance
     */
    public CheckoutOrderData setMerchantReference1(final String reference) {
        this.merchantReference1 = reference;

        return this;
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
     * Sets the second merchant reference.
     *
     * @param reference Merchant reference
     * @return Same instance
     */
    public CheckoutOrderData setMerchantReference2(final String reference) {
        this.merchantReference2 = reference;

        return this;
    }

    /**
     * Gets the order creation date.
     *
     * @return Start time
     */
    public DateTime getStartedAt() {
        return this.startedAt;
    }

    /**
     * Gets the time when the merchant completed the order.
     *
     * @return Completion time
     */
    public DateTime getCompletedAt() {
        return this.completedAt;
    }

    /**
     * Gets the last modified time.
     *
     * @return Modification time
     */
    public DateTime getLastModifiedAt() {
        return this.lastModifiedAt;
    }

    /**
     * Gets the checkout options.
     *
     * @return Checkout options
     */
    public CheckoutOptions getOptions() {
        return this.options;
    }

    /**
     * Sets the checkout options.
     *
     * @param options Checkout options
     * @return Same instance
     */
    public CheckoutOrderData setOptions(final CheckoutOptions options) {
        this.options = options;

        return this;
    }

    /**
     * Gets the GUI options.
     *
     * @return GUI options
     */
    public Gui getGui() {
        return this.gui;
    }

    /**
     * Sets the GUI options.
     *
     * @param gui GUI options
     * @return Same instance
     */
    public CheckoutOrderData setGui(final Gui gui) {
        this.gui = gui;

        return this;
    }

    /**
     * Get the attachment.
     *
     * @return Attachment.
     */
    public Attachment getAttachment() {
        return this.attachment;
    }

    /**
     * Set the attachment.
     *
     * @param attachment Attachment.
     * @return Same instance.
     */
    public CheckoutOrderData setAttachment(final Attachment attachment) {
        this.attachment = attachment;

        return this;
    }

    /**
     * Get the list of external payment methods.
     *
     * @return List of external payment methods.
     */
    public List<ExternalPaymentMethod> getExternalPaymentMethods() {
        return this.externalPaymentMethods;
    }

    /**
     * Set the list of external payment methods.
     *
     * @param externalPaymentMethods List of external payment methods.
     * @return Same instance.
     */
    public CheckoutOrderData setExternalPaymentMethods(
            final List<ExternalPaymentMethod> externalPaymentMethods) {
        this.externalPaymentMethods = externalPaymentMethods;

        return this;
    }

    /**
     * Get the list of external checkouts.
     *
     * @return List of external checkouts.
     */
    public List<ExternalCheckout> getExternalCheckouts() {
        return this.externalCheckouts;
    }

    /**
     * Set the list of external checkouts.
     *
     * @param externalCheckouts List of external checkouts.
     * @return Same instance.
     */
    public CheckoutOrderData setExternalCheckouts(
            final List<ExternalCheckout> externalCheckouts) {
        this.externalCheckouts = externalCheckouts;

        return this;
    }

    public CheckoutOrderData addShippingCountriesItem(String shippingCountriesItem) {
        if (this.shippingCountries == null) {
            this.shippingCountries = new ArrayList<String>();
        }
        this.shippingCountries.add(shippingCountriesItem);
        return this;
    }

    /**
     * Gets list of countries.
     *
     * @return shippingCountries
     **/
    public List<String> getShippingCountries() {
        return this.shippingCountries;
    }

    /**
     * Sets list of countries.
     *
     * @param shippingCountries
     * @return Same instance.
     */
    public CheckoutOrderData setShippingCountries(List<String> shippingCountries) {
        this.shippingCountries = shippingCountries;

        return this;
    }

    public CheckoutOrderData addShippingOptionsItem(ShippingOption shippingOptionsItem) {
        if (this.shippingOptions == null) {
            this.shippingOptions = new ArrayList<ShippingOption>();
        }
        this.shippingOptions.add(shippingOptionsItem);
        return this;
    }

    /**
     * Gets a list of shipping options available for this order.
     * @return shippingOptions
     **/
    public List<ShippingOption> getShippingOptions() {
        return this.shippingOptions;
    }

    /**
     * Sets a list of shipping options available for this order.
     * @return Same instance.
     **/
    public CheckoutOrderData setShippingOptions(List<ShippingOption> shippingOptions) {
        this.shippingOptions = shippingOptions;
        return this;
    }

    /**
     * Gets pass through field.
     * @return merchantData
     **/
    public String getMerchantData() {
        return this.merchantData;
    }

    /**
     * Sets pass through field.
     *
     * @param merchantData
     * @return Same instance.
     */
    public CheckoutOrderData setMerchantData(String merchantData) {
        this.merchantData = merchantData;
        return this;
    }

    /**
     * Stores merchant requested data.
     *
     * @return merchantRequested
     **/
    public MerchantRequested getMerchantRequested() {
        return this.merchantRequested;
    }

    /**
     * Gets current shipping options selected by the customer.
     *
     * @return selectedShippingOption
     **/
    public ShippingOption getSelectedShippingOption() {
        return this.selectedShippingOption;
    }

    /**
     * Gets recurring flag.
     * @return recurring
     **/
    public Boolean getRecurring() {
        return this.recurring;
    }

    /**
     * Sets recurring flag.
     *
     * @param recurring
     * @return Same instance.
     */
    public CheckoutOrderData setRecurring(Boolean recurring) {
        this.recurring = recurring;
        return this;
    }

    /**
     * Gets Token to be used when creating recurring orders.
     *
     * @return recurringToken
     **/
    public String getRecurringToken() {
        return this.recurringToken;
    }

    /**
     * Gets description recurring subscription.
     *
     * @return recurringDescription
     **/
    public String getRecurringDescription() {
        return this.recurringDescription;
    }
}
