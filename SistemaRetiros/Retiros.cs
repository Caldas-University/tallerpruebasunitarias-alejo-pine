using System;

namespace SistemaRetiros
{
    public class Retiro
    {
        public bool ValidarRetiro(decimal montoSolicitado, decimal saldoCuenta, decimal limiteDiario, bool cuentaActiva, bool cuentaBloqueadaPorFraude)
        {
            if (!cuentaActiva) return false;
            if (montoSolicitado > saldoCuenta) return false;
            if (montoSolicitado > limiteDiario) return false;
            if (cuentaBloqueadaPorFraude) return false;
            if (montoSolicitado % 10 != 0) return false;

            return true;
        }
    }
}
