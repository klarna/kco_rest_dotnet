using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication;
using Klarna.Rest.Core.Commuication.Dto;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Store
{
    /// <summary>
    /// This API gives you access to your payouts and transactions.
    /// Resources are split into two broad types:
    /// * Collections, including pagination information: collections are queryable, typically by the attributes of the sub-resource as well as pagination.
    /// * Entity resources containing a single entity.
    /// </summary>
    public class SettlementStore : BaseStore
    {
        internal SettlementStore(ApiSession apiSession, IJsonSerializer jsonSerializer) : base(apiSession, ApiControllers.SettlementPayouts, jsonSerializer) { }

        /// <summary>
        /// Returns a summary of payouts for each currency code in a date range.
        /// </summary>
        /// <param name="startDate">ISO-8601 formatted date with optional time string</param>
        /// <param name="endDate">ISO-8601 formatted date with optional time string</param>
        /// <param name="currencyCode">ISO-3166 Currency Code.</param>
        /// <returns>Collection of <see cref="SettlementsPayoutSummary"/></returns>
        public async Task<ICollection<SettlementsPayoutSummary>> GetPayoutsSummary(string startDate, string endDate, string currencyCode)
        {
            var nvm = new NameValueCollection
            {
                {"start_date", startDate},
                {"end_date", endDate},
                {"currency_code", currencyCode}
            };
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, "summary", nvm);

            var response = await Get<ICollection<SettlementsPayoutSummary>>(url);

            return response;
        }

        /// <summary>
        /// Returns a specific payout based on a given payment reference.
        /// </summary>
        /// <param name="paymentReference">The reference id of the payout</param>
        /// <returns>A single <see cref="SettlementsPayout"/> object</returns>
        public async Task<SettlementsPayout> GetPayout(string paymentReference)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, paymentReference);

            var response = await Get<SettlementsPayout>(url);

            return response;
        }

        /// <summary>
        /// Returns a collection of payouts.
        /// </summary>
        /// <param name="startDate">Optional. ISO-8601 formatted date with optional time string</param>
        /// <param name="endDate">Optional. ISO-8601 formatted date with optional time string</param>
        /// <param name="currencyCode">Optional. ISO-3166 Currency Code.</param>
        /// <param name="size">Optional. How many elements to include in the result. If no value for size is provided, a default of 20 will be used.</param>
        /// <param name="offset">Optional. The current offset. Describes "where" in a collection the current starts.</param>
        /// <returns><see cref="SettlementsGetAllPayoutsResponse"/></returns>
        public async Task<SettlementsGetAllPayoutsResponse> GetAllPayouts(string startDate = "", string endDate = "", string currencyCode = "",
            int size = 0, int offset = 0)
        {
            var nvm = new NameValueCollection();
            if (!string.IsNullOrEmpty(startDate))
            {
                nvm.Add("start_date", startDate);
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                nvm.Add("end_date", endDate);
            }

            if (!string.IsNullOrEmpty(currencyCode))
            {
                nvm.Add("currency_code", currencyCode);
            }

            if (size > 0)
            {
                nvm.Add("size", size.ToString("F0"));
            }

            if (offset > 0)
            {
                nvm.Add("offset", offset.ToString("F0"));
            }

            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, null, nvm);

            var response = await Get<SettlementsGetAllPayoutsResponse>(url);

            return response;
        }

        /// <summary>
        /// Returns a collection of transactions.
        /// </summary>
        /// <param name="paymentReference">Optional. The reference id of the payout</param>
        /// <param name="orderId">Optional. The Klarna assigned order id reference</param>
        /// <param name="size">Optional. How many elements to include in the result. If no value for size is provided, a default of 20 will be used.</param>
        /// <param name="offset">Optional. The current offset. Describes "where" in a collection the current starts.</param>
        /// <returns></returns>
        public async Task<SettlementsGetTransactionsResponse> GetTransactions(string paymentReference = "", string orderId = "",
            int size = 0, int offset = 0)
        {
            var nvm = new NameValueCollection();
            if (!string.IsNullOrEmpty(paymentReference))
            {
                nvm.Add("payment_reference", paymentReference);
            }

            if (!string.IsNullOrEmpty(orderId))
            {
                nvm.Add("order_id", orderId);
            }

            if (size > 0)
            {
                nvm.Add("size", size.ToString("F0"));
            }

            if (offset > 0)
            {
                nvm.Add("offset", offset.ToString("F0"));
            }

            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllers.SettlementTransactions, null, nvm);

            var response = await Get<SettlementsGetTransactionsResponse>(url);

            return response;
        }

        /// <summary>
        /// Get CSV Payout Report
        /// More information about this CSV format is available at:
        /// <a href="https://developers.klarna.com/en/gb/kco-v3/settlement-files">https://developers.klarna.com/en/gb/kco-v3/settlement-files</a>
        /// </summary>
        /// <param name="paymentReference">The reference id of the payout</param>
        /// <returns>A <see cref="Stream"/> of content type text/csv</returns>
        public async Task<Stream> GetCsvPayoutReport(string paymentReference)
        {
            var nvm = new NameValueCollection{{"payment_reference", paymentReference}};

            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllers.SettlementReports, "payout-with-transactions", nvm);

            return await GetStream(url);
        }

        /// <summary>
        /// Get CSV summary
        /// More information about this CSV format is available at:
        /// <a href="https://developers.klarna.com/en/gb/kco-v3/settlement-files">https://developers.klarna.com/en/gb/kco-v3/settlement-files</a>
        /// </summary>
        /// <param name="startDate">Required. ISO-8601 formatted date with optional time string</param>
        /// <param name="endDate">Required. ISO-8601 formatted date with optional time string</param>
        /// <returns>A <see cref="Stream"/> of content type text/csv</returns>
        public async Task<Stream> GetCsvSummary(string startDate, string endDate)
        {
            var nvm = new NameValueCollection
            {
                { "start_date", startDate },
                { "end_date", endDate }
            };

            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllers.SettlementReports, "payouts-summary-with-transactions", nvm);

            return await GetStream(url);
        }

        /// <summary>
        /// A single settlement summed up in pdf format
        /// </summary>
        /// <param name="paymentReference">Required. The reference id of the payout</param>
        /// <returns>A <see cref="Stream"/> of content type application/pdf</returns>
        public async Task<Stream> GetPdfPayoutSummary(string paymentReference)
        {
            var nvm = new NameValueCollection { { "payment_reference", paymentReference } };

            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllers.SettlementReports, "payout", nvm);

            return await GetStream(url);
        }

        /// <summary>
        /// Returns a summary for all payouts between the given dates
        /// </summary>
        /// <param name="startDate">Required. ISO-8601 formatted date with optional time string</param>
        /// <param name="endDate">Required. ISO-8601 formatted date with optional time string</param>
        /// <returns>A <see cref="Stream"/> of content type application/pdf</returns>
        public async Task<Stream> GetPdfSummary(string startDate, string endDate)
        {
            var nvm = new NameValueCollection
            {
                { "start_date", startDate },
                { "end_date", endDate }
            };

            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllers.SettlementReports, "payouts-summary", nvm);

            return await GetStream(url);
        }

    }
}
