// ************************************************************
// Assembly                 : Cuab Project Allocation
// Author                   : Sheriff Olamilekan
// CreatedOn                : 30-04-2022
//
// Last modified By:        : Sheriff Olamilekan
// Last Modified On:        : 04-05-2022
// ***********************************************************
// <copyright file="BaseApiController.cs" company="CuabProjectAllocation"
// </copyright>
// <summary></summary>
// ***********************************************************

using CuabProjectAllocation.Core.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace CuabProjectAllocation.Api.Controllers
{
    /// <summary>
    /// Class BaseApiController
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>

    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Gets the client Ip
        /// </summary>
        /// <value>The client IP</value>
        
        protected string ClientIP
        {
            get
            {
                var remoteIpAddress = GetRequestIP(true);
                return remoteIpAddress;
            }
        }

        /// <summary>
        /// Gets the request IP.
        /// </summary>
        /// <param name="tryUseXForwardHeader"></param>
        /// <returns></returns>
        private string GetRequestIP(bool tryUseXForwardHeader = true)
        {
            string ip = "";
            
            if (tryUseXForwardHeader)
                ip = GetHeaderValueAs<string>("X-Forwarded-For").SplitCsv().FirstOrDefault();
            
            if(string.IsNullOrWhiteSpace(ip) && HttpContext?.Connection?.RemoteIpAddress != null)
                ip = HttpContext.Connection.RemoteIpAddress.ToString();

            if (string.IsNullOrEmpty(ip))
                ip = GetHeaderValueAs<string>("REMOTE_ADDR");

            if (string.IsNullOrWhiteSpace(ip))
                ip = "";

            return ip;
        }

        /// <summary>
        /// Gets the header value as
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="headerName"></param>
        /// <returns></returns>
        private T GetHeaderValueAs<T>(string headerName)
        {
            StringValues values;

            if(HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                var rawValues = values.ToString();

                if(!string.IsNullOrEmpty(rawValues))              
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));                 
            }
            return default(T);
        }
    }
}
