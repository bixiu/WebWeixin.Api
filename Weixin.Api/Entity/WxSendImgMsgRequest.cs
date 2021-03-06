﻿using System;

namespace Weixin.Api.Entity
{
    public class WxSendImgMsgRequest : WeixinRequest<WxSendImgMsgResponse>
    {
        public int Scene { get; set; }

        public WxImgMsg Message { get; set; }

        public WxBaseRequest BaseRequest { get; set; }

        public override string QueryString
        {
            get
            {
                var msg = new _WxSendImgMsgRequest
                {
                    BaseRequest = this.BaseRequest,
                    Scene = this.Scene,
                    Msg = this.Message
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/cgi-bin/mmwebwx-bin/webwxsendmsgimg?fun=async&f=json&lang={1}&pass_ticket={2}",
                    this.Host,
                    this.Lang,
                    this.PassTicket);
            }
        }

        /// <summary>
        /// IWeixinClient会自动设置Host，手工设置的值会被覆盖
        /// </summary>
        public string Host { get; set; }

        public string Lang { get; set; }

        public string PassTicket { get; set; }

        public override string Accept
        {
            get
            {
                return "application/json, text/plain, */*";
            }
        }

        public class _WxSendImgMsgRequest
        {
            public WxBaseRequest BaseRequest { get; set; }

            public int Scene { get; set; }

            public WxImgMsg Msg { get; set; }
        }

        public WxSendImgMsgRequest()
            : base()
        {
            this.Host = "wx2.qq.com";
            this.Referer = "https://wx2.qq.com/?&lang=zh_CN";
            this.Origin = "https://wx2.qq.com";
            this.HttpMethod = Enum.HttpMethods.POST;
            this.ContentType = Enum.ContentTypes.JSON;
            this.KeepAlive = true;
            this.Scene = 0;
        }

        public WxSendImgMsgRequest(WxImgMsg msg, string passTicket, string lang = "zh_CN", int scene = 0)
            : this()
        {
            this.Message = msg;
            this.PassTicket = passTicket;
            this.Lang = lang;
            this.Scene = scene;
        }
    }
}