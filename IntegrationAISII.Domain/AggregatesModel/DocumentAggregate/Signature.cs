using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate
{
    public class Signature : Entity, ISignature
    {
        private long _versionId;
        private Version _version;
        private string _signer;
        private DateTime _signTime;
        private byte[] _value;

        /// <summary>
        /// Имя подписавшего
        /// </summary>
        public string Signer { get => _signer; }
        /// <summary>
        /// Дата/время подписи
        /// </summary>
        public DateTime SignTime { get => _signTime; }
        /// <summary>
        /// Значение подписи в формате криптосообщения PKCS#7
        /// </summary>
        public byte[] Value { get => _value; }

        public Signature(Version version, string signer, DateTime signTime, byte[] value)
        {
            _version = version is not null ? version : throw new ArgumentNullException(nameof(version));
            _signer = !string.IsNullOrWhiteSpace(signer) ? signer : throw new IntegrationAISIIDomainException($"Invalid {nameof(signer)} must not be empty");
            _signTime = signTime;
            _value = value is not null ? value : throw new ArgumentNullException(nameof(value));
        }

        public bool IsEquals(string signer, DateTime signTime, byte[] value) 
        {
            var isSimilarSigner = string.Equals(this._signer, signer);
            var isSimilarSignTime = DateTime.Compare(this._signTime, signTime) == 0;
            var isSimilarValue = this._value.SequenceEqual(value);
            return (isSimilarSigner && isSimilarSignTime && isSimilarValue); 
        }
    }
}
