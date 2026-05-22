# 🧪 Día 08 - Azure API Management y Application Insights

## 🎯 Objetivos

- Entender qué es Azure API Management
- Publicar y proteger APIs
- Comprender políticas de API Management
- Entender qué es Application Insights
- Monitorear aplicaciones y APIs
- Analizar métricas y logs

---

# 🧠 Conceptos clave

- APIs
- API Gateway
- Policies
- Monitoring
- Telemetry
- Logs
- Metrics

---

# 🧩 Introducción

Las aplicaciones modernas necesitan:

- exponer APIs
- proteger endpoints
- controlar acceso
- monitorear comportamiento
- detectar errores y problemas de rendimiento

👉 Azure API Management y Application Insights ayudan a resolver estos escenarios.

---

# 🌐 Azure API Management (APIM)

## 🧠 ¿Qué es?

Azure API Management es un gateway para publicar, proteger y administrar APIs.

👉 Funciona como una capa intermedia entre:
- clientes
- aplicaciones
- backend APIs

---

# 🎯 ¿Para qué se usa?

- centralizar APIs
- proteger endpoints
- aplicar autenticación
- limitar consumo
- versionar APIs
- monitorear tráfico

---

# Laboratorios
Xlabs: [AZ-204T00-A-AZH-CEP-M01] Import and configure an API with Azure API Management

https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-api-mgmt/01-api-mgmt-import-api.html

---

# 💡 Arquitectura conceptual

```text
Cliente
   ↓
API Management
   ↓
Backend API
```

---

# 🔥 Beneficios principales

- Seguridad
- Centralización
- Escalabilidad
- Control de acceso
- Observabilidad

---

# 🖥️ Demo (Portal)

Crear:

- API Management
- Importar una API
- Probar endpoints

---

# 🔒 Seguridad en APIM

## 🔹 Subscription Keys

Permiten controlar acceso a APIs.

👉 El cliente debe enviar una key válida.

---

## 🔹 OAuth / JWT

APIM puede validar tokens y proteger APIs.

---

# ⚙️ Policies

## 🧠 ¿Qué son?

Reglas que permiten modificar comportamiento de las APIs.

---

# 💡 Ejemplos

- validar JWT
- limitar requests
- transformar respuestas
- agregar headers
- cachear respuestas

---

# 🚦 Rate Limiting

## 🧠 ¿Qué permite?

Limitar cantidad de requests.

👉 Ejemplo:

```text
100 requests por minuto
```

---

# 🔥 Versionado de APIs

Permite publicar múltiples versiones de una API.

👉 Ejemplo:

```text
/api/v1/products
/api/v2/products
```

---

# 📊 Application Insights

## 🧠 ¿Qué es?

Servicio de monitoreo y observabilidad para aplicaciones.

👉 Permite:
- detectar errores
- analizar rendimiento
- monitorear requests
- visualizar telemetría

---

# 🎯 ¿Para qué se usa?

- monitoreo de aplicaciones
- troubleshooting
- métricas
- logs
- performance

---

# 🔥 Información que recopila

- requests
- excepciones
- tiempos de respuesta
- dependencias
- logs
- métricas

---

# 🖥️ Demo (Portal)

Mostrar:

- Requests
- Failures
- Live Metrics
- Logs

---

# 📈 Live Metrics

Permite visualizar métricas en tiempo real.

👉 Muy útil para troubleshooting.

---

# 💥 Exceptions

Application Insights permite detectar:
- errores
- stack traces
- excepciones no controladas

---

# 🔍 Logs y consultas

## 🧠 Kusto Query Language (KQL)

Permite consultar telemetría y logs.

---

# 💡 Ejemplo conceptual

```kusto
requests
| where success == false
```

---

# ⚡ Distributed Tracing

Permite seguir requests entre múltiples servicios.

👉 Muy útil en microservicios.

---

# 🔗 Integración APIM + App Insights

## 🧠 Escenario típico

```text
Cliente
   ↓
API Management
   ↓
Backend API
   ↓
Application Insights
```

👉 Permite monitorear:
- tráfico
- errores
- latencia
- consumo

---

# 🧪 Laboratorio

## Objetivo

- Crear API Management
- Importar API
- Aplicar policy simple
- Habilitar Application Insights
- Visualizar telemetría

---

# ⚠️ Notas importantes

- API Management puede tardar bastante en aprovisionar
- Application Insights genera costos según volumen de datos
- No exponer APIs sin autenticación

---

# 📌 Resumen

- API Management centraliza y protege APIs
- Policies permiten controlar comportamiento
- Application Insights monitorea aplicaciones
- Ambos servicios ayudan a mejorar seguridad y observabilidad

---

# ⚙️ Tiers de Azure API Management

## 🧠 Introducción

Azure API Management ofrece distintos tiers según:

- capacidad
- rendimiento
- disponibilidad
- networking
- características avanzadas

👉 La elección depende del escenario y tamaño de la solución.

---

# 🆓 Consumption Tier

## 🎯 Objetivo

Modelo serverless y pago por uso.

---

## ✅ Características

- Escalado automático
- Pago por request
- Ideal para cargas variables
- Bajo costo inicial

---

## 💡 Casos de uso

- desarrollo
- pruebas
- APIs pequeñas
- workloads eventuales

---

## ⚠️ Limitaciones

- menos funcionalidades avanzadas
- no recomendado para cargas críticas

---

# 🧪 Developer Tier

## 🎯 Objetivo

Entornos de desarrollo y testing.

---

## ✅ Características

- Bajo costo
- Todas las funcionalidades de APIM
- Ideal para aprendizaje y pruebas

---

## ⚠️ Limitaciones

- NO tiene SLA
- NO recomendado para producción

---

# 🚀 Basic Tier

## 🎯 Objetivo

Primer tier productivo.

---

## ✅ Características

- SLA incluido
- Mayor capacidad
- Producción pequeña/mediana

---

## 💡 Casos de uso

- APIs internas
- proyectos pequeños

---

# 🌐 Standard Tier

## 🎯 Objetivo

Producción con mayor escalabilidad.

---

## ✅ Características

- Escalado horizontal
- Mejor rendimiento
- Más capacidad

---

## 💡 Casos de uso

- APIs corporativas
- cargas medias/altas

---

# 🏢 Premium Tier

## 🎯 Objetivo

Escenarios enterprise.

---

## ✅ Características

- Multi-region
- Alta disponibilidad
- Máxima escalabilidad

---

## 💡 Casos de uso

- sistemas críticos
- arquitecturas globales
- enterprise

---

# ⚡ Isolated Tier

## 🎯 Objetivo

Máximo aislamiento y seguridad.

---

## ✅ Características

- Ejecuta en entorno aislado
- Alto nivel de seguridad
- Escenarios regulados

---

## 💡 Casos de uso

- banca
- gobierno
- compliance estricto

---

# 📌 Comparación rápida

| Tier | Uso principal |
|------|---------------|
| Consumption | serverless / bajo costo |
| Developer | desarrollo/testing |
| Basic | producción pequeña |
| Standard | producción escalable |
| Premium | enterprise/global |

---

# 📌 Recomendación general

- Developer → aprendizaje/labs
- Consumption → APIs pequeñas/serverless
- Basic/Standard → producción normal
- Premium → enterprise

# 🗣️ Preguntas para la clase

- ¿Qué problemas resuelve API Management?
- ¿Por qué limitar requests?
- ¿Qué ventajas tiene monitorear aplicaciones?
- ¿Cómo ayudaría Application Insights en producción?

---

# 🔄 Próximos pasos

En la próxima clase veremos:

- Azure Events and Messaging
- Integración basada en eventos