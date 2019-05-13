using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SGP.Enums
{
    public enum ETipoLancamento: int
    {
        Entrada = 1,
        SaidaAlmoco = 2,
        RetornoAlmoco = 3,
        FimTurno = 4
    }
}
