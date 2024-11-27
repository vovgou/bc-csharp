using System;

namespace Org.BouncyCastle.Tls.Crypto
{
    public sealed class TlsEncodeResult:IDisposable
    {
        public readonly byte[] buf;
        public readonly int off, len;
        public readonly short recordType;
        private bool pooled;
        public TlsEncodeResult(byte[] buf, int off, int len, short recordType):this(buf, off, len, recordType, false)
        {
        }

        public TlsEncodeResult(byte[] buf, int off, int len, short recordType,bool pooled)
        {
            this.buf = buf;
            this.off = off;
            this.len = len;
            this.recordType = recordType;
            this.pooled = pooled;
        }

        public void Dispose()
        {
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            if (pooled)
            {
                System.Buffers.ArrayPool<byte>.Shared.Return(buf);
                pooled = false;
            }
#endif
        }
    }
}
