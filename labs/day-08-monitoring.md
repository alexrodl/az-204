# 📊 Monitoreo en Azure - Azure Monitor y Application Insights

## 🎯 Objetivos

- Entender qué es Azure Monitor
- Comprender la diferencia entre métricas y logs
- Entender qué es Application Insights
- Aprender distintas formas de enviar telemetría
- Comprender observabilidad en aplicaciones modernas

---

# 🧠 ¿Por qué es importante el monitoreo?

Las aplicaciones modernas necesitan:

- detectar errores
- monitorear rendimiento
- analizar comportamiento
- diagnosticar problemas
- entender uso de la aplicación

👉 El monitoreo permite obtener visibilidad de los sistemas.

---

# 🌐 Azure Monitor

## 🧠 ¿Qué es?

Azure Monitor es la plataforma central de monitoreo de Azure.

👉 Permite recopilar:

- métricas
- logs
- telemetría
- eventos
- diagnósticos

desde:
- recursos Azure
- aplicaciones
- máquinas virtuales
- contenedores
- servicios

---

# 💡 Arquitectura conceptual

```text
Aplicaciones / Recursos Azure
            ↓
        Azure Monitor
            ↓
  Logs / Métricas / Alertas
```

---

# 📈 Métricas

## 🧠 ¿Qué son?

Información numérica recopilada en intervalos de tiempo.

👉 Son ligeras y rápidas.

---

# 💡 Ejemplos

- CPU %
- Requests por segundo
- Memoria utilizada
- Tiempo de respuesta
- Cantidad de requests

---

# 🎯 Características

- tiempo real
- alta performance
- series temporales
- ideales para dashboards y alertas

---

# 📋 Logs

## 🧠 ¿Qué son?

Información detallada de eventos y operaciones.

👉 Contienen más contexto que las métricas.

---

# 💡 Ejemplos

- excepciones
- requests HTTP
- logs de aplicación
- dependencias
- auditoría

---

# 🎯 Características

- más detallados
- permiten troubleshooting
- consultas avanzadas

---

# ⚖️ Diferencia entre métricas y logs

| Métricas | Logs |
|----------|------|
| Datos numéricos | Datos detallados |
| Livianas | Más pesados |
| Tiempo real | Diagnóstico profundo |
| Dashboards | Troubleshooting |

---

# 🔍 Log Analytics

## 🧠 ¿Qué es?

Servicio utilizado para consultar logs mediante KQL.

👉 Azure Monitor almacena información en Log Analytics Workspace.

---

# 💡 Ejemplo KQL

```kusto
requests
| where success == false
```

---

# 📊 Application Insights

## 🧠 ¿Qué es?

Servicio de monitoreo orientado a aplicaciones.

👉 Forma parte de Azure Monitor.

---

# 🎯 ¿Qué permite monitorear?

- requests
- excepciones
- performance
- dependencias
- logs
- usuarios
- telemetría distribuida

---

# 💡 Casos de uso

- detectar errores
- analizar performance
- troubleshooting
- observabilidad de APIs

---

# 🔥 Información que recopila

- requests HTTP
- exceptions
- traces
- dependencies
- availability
- custom telemetry

---

# 🖥️ Secciones importantes en App Insights

## 🔹 Requests
Requests HTTP de la aplicación.

---

## 🔹 Failures
Errores y excepciones.

---

## 🔹 Performance
Tiempo de respuesta y rendimiento.

---

## 🔹 Live Metrics
Métricas en tiempo real.

---

## 🔹 Logs
Consultas KQL.

---

# 🌐 Distributed Tracing

## 🧠 ¿Qué es?

Permite seguir una request entre múltiples servicios.

👉 Muy útil en microservicios.

---

# 💡 Ejemplo

```text
Frontend
   ↓
API
   ↓
Database
```

👉 App Insights puede mostrar todo el recorrido.

---

# 🚀 Formas de enviar telemetría a Application Insights

Azure ofrece distintas formas de enviar información.

---

# 🔹 Opción 1 - Instrumentation desde App Service

## 🧠 ¿Qué es?

Configuración automática desde Azure App Service.

👉 Sin modificar código.

---

# 🎯 ¿Cómo funciona?

Azure habilita automáticamente:
- monitoreo básico
- requests
- logs
- performance

---

# ✅ Ventajas

- muy simple
- rápida configuración
- ideal para demos/labs

---

# ⚠️ Limitaciones

- menos control
- telemetría básica

---

# 💡 Escenario típico

```text
App Service
   ↓
Enable Application Insights
   ↓
Telemetría automática
```

---

# 🔹 Opción 2 - SDK de Application Insights

## 🧠 ¿Qué es?

Uso de librerías oficiales de Application Insights en el código.

---

# 🎯 ¿Qué permite?

- custom telemetry
- logs personalizados
- eventos personalizados
- mayor control

---

# 💡 Ejemplo .NET

```csharp
builder.Services.AddApplicationInsightsTelemetry();
```

---

# 💡 Ejemplo custom event

```csharp
telemetryClient.TrackEvent("OrderCreated");
```

---

# ✅ Ventajas

- mayor control
- telemetría personalizada
- integración profunda

---

# ⚠️ Limitaciones

- requiere cambios de código
- dependiente del vendor

---

# 🔹 Opción 3 - OpenTelemetry

## 🧠 ¿Qué es?

Estándar abierto para observabilidad y telemetría.

👉 Vendor-neutral.

---

# 🎯 ¿Qué permite?

- logs
- métricas
- traces
- distributed tracing

---

# 💡 Ventajas

- estándar moderno
- portable
- compatible con múltiples plataformas

---

# 💡 Ejemplo conceptual

```text
Aplicación
   ↓
OpenTelemetry
   ↓
Azure Monitor / Otros vendors
```

---

# ✅ Ventajas

- independencia del proveedor
- observabilidad moderna
- multi-cloud

---

# ⚠️ Importante

Microsoft recomienda OpenTelemetry para nuevos desarrollos.

---

# ⚖️ Comparación rápida

| Método | Ventaja principal |
|--------|-------------------|
| App Service Integration | simple |
| SDK App Insights | control total |
| OpenTelemetry | estándar abierto |

---

# 🔥 Recomendación general

| Escenario | Recomendación |
|-----------|---------------|
| Demo/lab | App Service Integration |
| Aplicación enterprise | OpenTelemetry |
| Custom telemetry avanzada | SDK |

---

# 📌 Conceptos importantes

## 🔹 Telemetry
Información enviada por aplicaciones.

---

## 🔹 Observability
Capacidad de entender el estado interno del sistema.

---

## 🔹 Distributed Tracing
Seguimiento de requests entre servicios.

---

# 🧪 Demo recomendada

## Parte 1
Habilitar App Insights desde App Service.

---

## Parte 2
Generar tráfico y visualizar:
- requests
- failures
- logs

---

## Parte 3
Mostrar consultas KQL simples.

---

# ⚠️ Notas importantes

- Application Insights genera costos según volumen de datos
- Logs muy detallados pueden aumentar costos
- OpenTelemetry es el enfoque moderno recomendado

---

# 📌 Resumen

- Azure Monitor es la plataforma central de monitoreo
- Métricas y logs tienen objetivos distintos
- Application Insights monitorea aplicaciones
- Existen múltiples formas de enviar telemetría
- OpenTelemetry es el estándar moderno de observabilidad