using Adv.Domain.Common;
using NHibernate;

namespace Adv.Domain.NHibernate.Queries
{
    public class FindProductUOMByUOMCodeQuery : DefaultDomainQuery<UnitMeasure>
    {
        string _uomCode;
        public FindProductUOMByUOMCodeQuery(string uomCode)
        {
            _uomCode = uomCode;
        }

        public override IQueryOver<UnitMeasure, UnitMeasure> QueryOver(IQueryOver<UnitMeasure, UnitMeasure> query)
        {
            return base.QueryOver(query).Where(p=>p.UnitMeasureCode==_uomCode);
        }

    }
}
