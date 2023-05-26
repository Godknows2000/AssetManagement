using AMS.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data
{
    partial class AssetRequest : INotesContainer , IAttachmentsContainer
    {
        [NotMapped]
        public AssetStatus Status { get => (AssetStatus)(StatusId ?? 0); set => StatusId = (int)value; }
        [NotMapped]
        public bool IsApproved => Status == AssetStatus.APPROVED;
        [NotMapped]
        public bool IsAwaitingCreditProvider => Status == AssetStatus.AWAITING_APPROVAL;
        [NotMapped]
        public bool IsCanceled => Status == AssetStatus.CANCELED;
        [NotMapped]
        public bool IsClosed => Status == AssetStatus.CLOSED;
        [NotMapped]
        public bool IsCurrent => Status == AssetStatus.CURRENT;
    }
}
