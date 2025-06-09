using NUnit.Framework;
using SistemaRetiros; // Asegúrate de importar el espacio de nombres correcto
using System;

namespace SistemaRetiros.Tests
{
    public class RetiroTests
    {
        private Retiro _retiro;

        [SetUp]
        public void Setup()
        {
            _retiro = new Retiro(); // Instanciamos la clase Retiro antes de cada prueba
        }

        // TC1: Caso completamente válido
        [Test]
        public void TC1_CuentaActiva_SaldoSuficiente_MontoDentroDelLimite_CuentaNoBloqueada_MontoMultiploDe10()
        {
            bool resultado = _retiro.ValidarRetiro(100, 500, 200, true, false);
            Assert.IsTrue(resultado); // Se espera que el retiro sea aprobado
        }

        // TC2: Cuenta inactiva
        [Test]
        public void TC2_CuentaInactiva()
        {
            bool resultado = _retiro.ValidarRetiro(100, 500, 200, false, false);
            Assert.IsFalse(resultado); // Se espera que el retiro sea rechazado
        }

        // TC3: Saldo insuficiente
        [Test]
        public void TC3_SaldoInsuficiente()
        {
            bool resultado = _retiro.ValidarRetiro(100, 50, 200, true, false);
            Assert.IsFalse(resultado); // Se espera que el retiro sea rechazado por saldo insuficiente
        }

        // TC4: Monto excede el límite
        [Test]
        public void TC4_MontoExcedeLimite()
        {
            bool resultado = _retiro.ValidarRetiro(300, 500, 200, true, false);
            Assert.IsFalse(resultado); // Se espera que el retiro sea rechazado por exceder el límite
        }

        // TC5: Cuenta bloqueada por fraude
        [Test]
        public void TC5_CuentaBloqueadaPorFraude()
        {
            bool resultado = _retiro.ValidarRetiro(100, 500, 200, true, true);
            Assert.IsFalse(resultado); // Se espera que el retiro sea rechazado
        }

        // TC6: Monto no múltiplo de 10
        [Test]
        public void TC6_MontoNoMultiploDe10()
        {
            bool resultado = _retiro.ValidarRetiro(105, 500, 200, true, false);
            Assert.IsFalse(resultado); // Se espera que el retiro sea rechazado por no ser múltiplo de 10
        }
    }
}
