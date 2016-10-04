﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace WebAppMETANIT.Filter
{
    public class WhitespaceAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            if (filterContext.HttpContext.Request.RawUrl == "/sitemap.xml") return;

            if (response.ContentType != "text/html" || response.Filter == null) return;

            response.Filter = new SpaceCleaner(response.Filter);
        }

        private class SpaceCleaner : Stream
        {
            private readonly Stream outputStream;
            StringBuilder _s = new StringBuilder();

            public SpaceCleaner(Stream filterStream)
            {
                if (filterStream == null)
                    throw new ArgumentNullException("filterStream is not determined");
                outputStream = filterStream;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                var html = Encoding.UTF8.GetString(buffer, offset, count);

                var reg = new Regex(@"(?<=\s)\s+(?![^<>]*</pre>)");
                html = reg.Replace(html, string.Empty);
                buffer = Encoding.UTF8.GetBytes(html);
                outputStream.Write(buffer, 0, buffer.Length);
            }

            #region Other
            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
            public override bool CanRead { get { return false; } }
            public override bool CanSeek { get { return false; } }
            public override bool CanWrite { get { return true; } }
            public override long Length { get { throw new NotSupportedException(); } }
            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
            public override void Flush()
            {
                outputStream.Flush();
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
        }
        #endregion
    }
}