using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Persistent.AuditTrail;

namespace CooperativaIT.Module.BusinessObjects.Seguridad
{
    public static class AuditTrailConfig
    {
        public static void Initialize()
        {
            AuditTrailService.Instance.SaveAuditTrailData += Instance_SaveAuditTrailData;
        }

        static void Instance_SaveAuditTrailData(object sender, SaveAuditTrailDataEventArgs e)
        {
            List<AuditDataItem> toDelete = new List<AuditDataItem>();
            foreach (var item in e.AuditTrailDataItems)
            {
                if (item.OperationType == AuditOperationType.ObjectChanged || item.OperationType == AuditOperationType.ObjectDeleted) continue;
                toDelete.Add(item);
            }
            foreach (var item in toDelete)
            {
                e.AuditTrailDataItems.Remove(item);
            }
        }
    }
}
