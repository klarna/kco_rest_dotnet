#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ExtraMerchantDataBody.cs" company="Klarna AB">
//     Copyright 2015 Klarna AB
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------
#endregion
namespace Klarna.Rest.Models.EMD
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The model for EMD attachment body.
    /// </summary>
    public class ExtraMerchantDataBody : Model
    { 
        /// <summary>
        /// Gets or sets the list of air reservation details.
        /// </summary>
        [JsonProperty("air_reservation_details")]
        public List<AirReservationDetails> AirReservationDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of bus reservation details.
        /// </summary>
        [JsonProperty("bus_reservation_details")]
        public List<BusReservationDetails> BusReservationDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of train reservation details.
        /// </summary>
        [JsonProperty("train_reservation_details")]
        public List<TrainReservationDetails> TrainReservationDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of ferry reservation details.
        /// </summary>
        [JsonProperty("ferry_reservation_details")]
        public List<FerryReservationDetails> FerryReservationDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of hotel reservation details.
        /// </summary>
        [JsonProperty("hotel_reservation_details")]
        public List<HotelReservationDetails> HotelReservationDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of car rental reservation details.
        /// </summary>
        [JsonProperty("car_rental_reservation_details")]
        public List<CarRentalReservationDetails> CarRentalReservationDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of events.
        /// </summary>
        [JsonProperty("event")]
        public List<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets the list of vouchers.
        /// </summary>
        [JsonProperty("voucher")]
        public List<Voucher> Vouchers { get; set; }

        /// <summary>
        /// Gets or sets the list of subscriptions.
        /// </summary>
        [JsonProperty("subscription")]
        public List<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// Gets or sets the list of customer account information.
        /// </summary>
        [JsonProperty("customer_account_info")]
        public List<CustomerAccountInformation> CustomerAccountInfo { get; set; }

        /// <summary>
        /// Gets or sets the list of marketplace seller information.
        /// </summary>
        [JsonProperty("marketplace_seller_info")]
        public List<MarketplaceSellerInformation> MarketplaceSellerInformation { get; set; }

        /// <summary>
        /// Gets or sets the list of marketplace winner information.
        /// </summary>
        [JsonProperty("marketplace_winner_info")]
        public List<MarketplaceWinnerInformation> MarketplaceWinnerInformation { get; set; }

        /// <summary>
        /// Gets or sets the list of full purchase histories.
        /// </summary>
        [JsonProperty("purchase_history_full")]
        public List<PurchaseHistoryFull> PurchaseHistoryFull { get; set; }

        /// <summary>
        /// Gets or sets the list of simple purchase histories.
        /// </summary>
        [JsonProperty("purchase_history_simple")]
        public List<PurchaseHistorySimple> PurchaseHistorySimple { get; set; }

        /// <summary>
        /// Gets or sets the list of other delivery addresses.
        /// </summary>
        [JsonProperty("other_delivery_address")]
        public List<OtherDeliveryAddress> OtherDeliveryAddresses { get; set; }
    }
}
