#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="RequestFactoryTests.cs" company="Klarna AB">
//     Copyright 2014 Klarna AB
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
namespace Klarna.Rest.Tests.Transport
{
    using System.IO;
    using System.Net;
    using System.Text;
    using Klarna.Rest.Transport;
    using NUnit.Framework;
    using Rhino.Mocks;

    /// <summary>
    /// Tests the RequestFactory class.
    /// </summary>
    [TestFixture]
    public class RequestFactoryTests
    {
        #region Private Fields

        /// <summary>
        /// Request stub.
        /// </summary>
        private HttpWebRequest request;

        /// <summary>
        /// Response stub.
        /// </summary>
        private HttpWebResponse response;

        /// <summary>
        /// The request factory.
        /// </summary>
        private RequestFactory factory;

        #endregion

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.request = MockRepository.GenerateStub<HttpWebRequest>();
            this.response = MockRepository.GenerateStub<HttpWebResponse>();

            var headers = new WebHeaderCollection();
            headers["Location"] = "http://somewhere/123";

            Stream stream = new MemoryStream();
            var payload = Encoding.UTF8.GetBytes("{}");
            stream.Write(payload, 0, payload.Length);
            stream.Seek(0, SeekOrigin.Begin);

            this.response.Stub(x => x.Headers).Return(headers);
            this.response.Stub(x => x.StatusCode).Return(HttpStatusCode.Created);
            this.response.Stub(x => x.ContentType).Return("application/json");
            this.response.Stub(x => x.ContentLength).Return(payload.Length);
            this.response.Stub(x => x.GetResponseStream()).Return(stream);

            this.factory = new RequestFactory();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Basic test of CreateRequest.
        /// </summary>
        [Test]
        public void Transport_RequestFactory_CreateRequest()
        {
            const string Url = "https://localhost/path";
            HttpWebRequest request = this.factory.CreateRequest(Url);

            Assert.AreEqual(request.RequestUri, Url);
        }

        /// <summary>
        /// Basic test of Send.
        /// </summary>
        [Test]
        public void Transport_RequestFactory_Send()
        {
            this.request.Stub(x => x.GetResponse()).Return(this.response);

            IResponse response = this.factory.Send(this.request, null);

            Assert.AreEqual(HttpStatusCode.Created, response.Status);
            Assert.AreEqual("http://somewhere/123", response.Headers["Location"]);
            Assert.AreEqual("{}", response.Payload);
        }

        /// <summary>
        /// Basic test of Send with a payload.
        /// </summary>
        [Test]
        public void Transport_RequestFactory_SendWithPayload()
        {
            string payload = "{\"something\": \"else\"}";
            var bytes = Encoding.UTF8.GetBytes(payload);

            var stream = MockRepository.GenerateStub<Stream>();
            stream.Expect(x => x.Write(bytes, 0, 21));

            this.request.Stub(x => x.GetRequestStream()).Return(stream);
            this.request.Stub(x => x.GetResponse()).Return(this.response);

            IResponse response = this.factory.Send(this.request, payload);

            stream.VerifyAllExpectations();

            Assert.AreEqual(21, this.request.ContentLength);
            Assert.AreEqual(HttpStatusCode.Created, response.Status);
            Assert.AreEqual("http://somewhere/123", response.Headers["Location"]);
            Assert.AreEqual("{}", response.Payload);
        }

        /// <summary>
        /// Ensure that the ErrorMessage model is populated correctly for API errors.
        /// </summary>
        [Test]
        public void Transport_RequestFactory_SendWithApiError()
        {
            this.response.BackToRecord(BackToRecordOptions.All);
            this.response.Replay();

            Stream stream = new MemoryStream();
            var payload = Encoding.UTF8.GetBytes("{\r\n \"error_code\": \"111\", \"correlation_id\": \"222\", \"error_messages\": [\"one\", \"two\"]}");
            stream.Write(payload, 0, payload.Length);
            stream.Seek(0, SeekOrigin.Begin);

            this.response.Stub(x => x.StatusCode).Return(HttpStatusCode.BadRequest);
            this.response.Stub(x => x.ContentType).Return("application/json");
            this.response.Stub(x => x.ContentLength).Return(payload.Length);
            this.response.Stub(x => x.GetResponseStream()).Return(stream);

            WebException exception = new WebException("The remote server returned an error: (400) Bad Request.", null, WebExceptionStatus.Success, this.response);

            this.request.Stub(x => x.GetResponse()).Throw(exception);

            try
            {
                this.factory.Send(this.request, null);
                Assert.Fail("No exception was thrown");
            }
            catch (ApiException ex)
            {
                Assert.AreEqual("The remote server returned an error: (400) Bad Request.", ex.Message);
                Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);

                Assert.AreEqual("111", ex.ErrorMessage.ErrorCode);
                Assert.AreEqual("222", ex.ErrorMessage.CorrelationId);
                Assert.AreEqual(new string[] { "one", "two" }, ex.ErrorMessage.ErrorMessages);
            }
        }

        /// <summary>
        /// Ensure that the original WebException is thrown when the API did not respond with JSON.
        /// </summary>
        [Test]
        public void Transport_RequestFactory_SendWithIncorrectContentType()
        {
            this.response.BackToRecord(BackToRecordOptions.All);
            this.response.Replay();

            Stream stream = new MemoryStream();
            var payload = Encoding.UTF8.GetBytes("<title>401 Authorization Required</title><center><h1>401 Authorization Required</h1></center><hr><center>nginx</center>");
            stream.Write(payload, 0, payload.Length);
            stream.Seek(0, SeekOrigin.Begin);

            this.response.Stub(x => x.StatusCode).Return(HttpStatusCode.Unauthorized);
            this.response.Stub(x => x.ContentType).Return("text/html");
            this.response.Stub(x => x.ContentLength).Return(payload.Length);
            this.response.Stub(x => x.GetResponseStream()).Return(stream);

            WebException exception = new WebException("The remote server returned an error: (401) Unauthorized.", null, WebExceptionStatus.Success, this.response);

            this.request.Stub(x => x.GetResponse()).Throw(exception);

            try
            {
                this.factory.Send(this.request, null);
                Assert.Fail("No exception was thrown");
            }
            catch (WebException ex)
            {
                Assert.AreSame(exception, ex);
            }
        }

        /// <summary>
        /// Ensure that the original WebException is thrown when the API responded with invalid JSON.
        /// </summary>
        [Test]
        public void Transport_RequestFactory_SendWithParseError()
        {
            this.response.BackToRecord(BackToRecordOptions.All);
            this.response.Replay();

            Stream stream = new MemoryStream();
            var payload = Encoding.UTF8.GetBytes("{");
            stream.Write(payload, 0, payload.Length);
            stream.Seek(0, SeekOrigin.Begin);

            this.response.Stub(x => x.StatusCode).Return(HttpStatusCode.InternalServerError);
            this.response.Stub(x => x.ContentType).Return("application/json");
            this.response.Stub(x => x.ContentLength).Return(payload.Length);
            this.response.Stub(x => x.GetResponseStream()).Return(stream);

            WebException exception = new WebException("The remote server returned an error: (500) Internal Serve rError.", null, WebExceptionStatus.Success, this.response);

            this.request.Stub(x => x.GetResponse()).Throw(exception);

            try
            {
                this.factory.Send(this.request, null);
                Assert.Fail("No exception was thrown");
            }
            catch (WebException ex)
            {
                Assert.AreSame(exception, ex);
            }
        }

        /// <summary>
        /// Ensure that the original WebException is thrown when the API did not respond at all.
        /// </summary>
        [Test]
        public void Transport_RequestFactory_SendExceptionWithoutResponse()
        {
            WebException exception = new WebException("Whatever", null, WebExceptionStatus.Timeout, null);

            this.request.Stub(x => x.GetResponse()).Throw(exception);

            try
            {
                this.factory.Send(this.request, null);
                Assert.Fail("No exception was thrown");
            }
            catch (WebException ex)
            {
                Assert.AreSame(exception, ex);
            }
        }

        /// <summary>
        /// Ensure that the ErrorMessage models properties are nullable
        /// </summary>
        [Test]
        public void Transport_RequestFactory_SendExceptionNullable()
        {
            Stream stream = new MemoryStream();
            var payload = Encoding.UTF8.GetBytes("{}");
            stream.Write(payload, 0, payload.Length);
            stream.Seek(0, SeekOrigin.Begin);

            this.response.Stub(x => x.StatusCode).Return(HttpStatusCode.BadRequest);
            this.response.Stub(x => x.ContentType).Return("application/json");
            this.response.Stub(x => x.ContentLength).Return(payload.Length);
            this.response.Stub(x => x.GetResponseStream()).Return(stream);

            WebException exception = new WebException("The remote server returned an error: (400) Bad Request.", null, WebExceptionStatus.Success, this.response);

            this.request.Stub(x => x.GetResponse()).Throw(exception);

            try
            {
                this.factory.Send(this.request, null);
                Assert.Fail("No exception was thrown");
            }
            catch (ApiException ex)
            {
                Assert.IsNull(ex.ErrorMessage.ErrorCode);
                Assert.IsNull(ex.ErrorMessage.CorrelationId);
                Assert.IsNull(ex.ErrorMessage.ErrorMessages);
            }
        }

        #endregion
    }
}
