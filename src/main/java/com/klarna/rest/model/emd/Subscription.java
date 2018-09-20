/*
 * Copyright 2015 Klarna AB
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

package com.klarna.rest.model.emd;

import org.joda.time.DateTime;

/**
 * The model for subscriptions.
 */
public class Subscription extends Model {
    /**
     * Subscription name.
     */
    private String subscriptionName;

    /**
     * Start time.
     */
    private DateTime startTime;

    /**
     * End time.
     */
    private DateTime endTime;

    /**
     * Is the subscription automatically renewed.
     */
    private Boolean autoRenewalOfSubscription;

    /**
     * Affiliate name.
     */
    private String affiliateName;

    /**
     * Get the subscription name.
     *
     * @return Subscription name.
     */
    public String getSubscriptionName() {
        return this.subscriptionName;
    }

    /**
     * Set the subscription name.
     *
     * @param subscriptionName Subscription name.
     * @return Same instance.
     */
    public Subscription setSubscriptionName(final String subscriptionName) {
        this.subscriptionName = subscriptionName;

        return this;
    }

    /**
     * Get the start time.
     *
     * @return Start time.
     */
    public DateTime getStartTime() {
        return this.startTime;
    }

    /**
     * Set the start time.
     *
     * @param startTime Start time.
     * @return Same instance.
     */
    public Subscription setStartTime(final DateTime startTime) {
        this.startTime = startTime;

        return this;
    }

    /**
     * Get the end time.
     *
     * @return End time.
     */
    public DateTime getEndTime() {
        return this.endTime;
    }

    /**
     * Set the end time.
     *
     * @param endTime End time.
     * @return Same instance
     */
    public Subscription setEndTime(final DateTime endTime) {
        this.endTime = endTime;

        return this;
    }

    /**
     * Is the subscription automatically renewed.
     *
     * @return True if the subscription if automatically renewed.
     */
    public Boolean isAutoRenewalOfSubscription() {
        return this.autoRenewalOfSubscription;
    }

    /**
     * Set whether the subscription is automatically renewed.
     *
     * @param autoRenewalOfSubscription If the subscription should be renewed.
     * @return Same instance.
     */
    public Subscription setAutoRenewalOfSubscription(
            final Boolean autoRenewalOfSubscription) {
        this.autoRenewalOfSubscription = autoRenewalOfSubscription;

        return this;
    }

    /**
     * Get the affiliate name.
     *
     * @return Affiliate name.
     */
    public String getAffiliateName() {
        return this.affiliateName;
    }

    /**
     * Set the affiliate name.
     *
     * @param affiliateName Affiliate name.
     * @return Same instance.
     */
    public Subscription setAffiliateName(
            final String affiliateName) {
        this.affiliateName = affiliateName;

        return this;
    }
}
