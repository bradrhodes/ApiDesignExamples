using System;
using System.Data;
using Dapper;

namespace ApiDesignExamples.NonCRUD.Dapper
{
    public class GuidTypeMapper : SqlMapper.TypeHandler<Guid>
    {
        public override void SetValue(IDbDataParameter parameter, Guid value)
        {
            parameter.Value = value.ToString();
        }

        public override Guid Parse(object value)
        {
            return new Guid((string) value);
        }
    }
}
