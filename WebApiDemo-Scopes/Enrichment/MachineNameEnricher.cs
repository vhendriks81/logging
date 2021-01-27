namespace WebApiDemo.Enrichment
{
    using System;
    using Serilog.Core;
    using Serilog.Events;

    public class MachineNameEnricher : ILogEventEnricher
    {
        LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(GetLogEventProperty(propertyFactory));
        }

        private LogEventProperty GetLogEventProperty(ILogEventPropertyFactory propertyFactory)
        {
            if (_cachedProperty == null)
                _cachedProperty = CreateProperty(propertyFactory);

            return _cachedProperty;
        }

        private static LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory)
        {
            var machineName = Environment.MachineName;

            return propertyFactory.CreateProperty("MachineName", machineName);
        }
    }
}
