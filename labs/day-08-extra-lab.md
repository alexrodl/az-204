# 🧪 Ejercicios adicionales - Azure API Management

## 🎯 Objetivos

- Comprender el valor real de API Management
- Proteger APIs mediante Subscription Keys
- Aplicar políticas (Policies)
- Limitar requests
- Modificar requests/responses sin cambiar el backend
- Explorar el Developer Portal

---

# 🧩 Introducción

Azure API Management no solo sirve para publicar APIs.

👉 También permite:

- proteger endpoints
- controlar tráfico
- transformar requests
- aplicar autenticación
- monitorear consumo

---

# 🧪 Parte 1 - Importar API

## Objetivo

Importar una API existente utilizando el laboratorio oficial.

👉 Laboratorio oficial:

[Laboratorio](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-api-mgmt/01-api-mgmt-import-api.html)

---

# 🔑 Parte 2 - Subscription Keys

## 🧠 ¿Qué son?

Permiten controlar quién puede consumir una API.

👉 El cliente debe enviar una key válida.

---

## 🔍 Paso 1

Ir a:

```text
API Management
→ Subscriptions
```

---

## 🔍 Paso 2

Copiar una Subscription Key.

---

## 🔍 Paso 3

Probar la API SIN key.

👉 Resultado esperado:

```http
401 Unauthorized
```

---

## 🔍 Paso 4

Agregar header:

```http
Ocp-Apim-Subscription-Key: <subscription-key>
```

👉 Resultado esperado:
- request exitosa

---

# 💡 ¿Por qué es importante?

Permite:
- controlar acceso
- identificar consumidores
- revocar accesos fácilmente

---

# 🚦 Parte 3 - Rate Limiting

## 🧠 Objetivo

Limitar cantidad de requests.

---

## 🔍 Paso 1

Ir a:

```text
API
→ Design
→ Inbound processing
→ Policies
```

---

## 🔍 Paso 2

Agregar policy:

```xml
<rate-limit calls="3" renewal-period="60" />
```

---

## 🔍 Paso 3

Ejecutar múltiples requests rápidamente.

👉 Resultado esperado:

```http
429 Too Many Requests
```

---

# 💡 ¿Por qué es importante?

Permite:
- proteger backend
- evitar abuso
- controlar consumo

---

# 🏷️ Parte 4 - Modificar Headers

## 🧠 Objetivo

Modificar requests o responses sin cambiar el backend.

---

## 🔍 Paso 1

Agregar policy:

```xml
<set-header name="X-Course" exists-action="override">
    <value>AZ-204</value>
</set-header>

<set-body>
{
  "message": "Interceptado por API Management"
}
</set-body>
```

---

## 🔍 Paso 2

Ejecutar request nuevamente.

👉 Verificar nuevo header y response

---

# 💡 ¿Por qué es importante?

Permite:
- agregar metadata
- transformar requests
- desacoplar backend y clientes

---

# 🔐 Parte 5 - Validación JWT (conceptual)

## 🧠 Objetivo

Entender cómo APIM puede proteger APIs usando tokens.

---

## 💡 Ejemplo conceptual

```xml
<validate-jwt ... />
```

👉 API Management puede:
- validar tokens
- verificar issuer
- verificar audience

---

# 💡 Relación con Entra ID

```text
Usuario
   ↓ login
Entra ID
   ↓ token JWT
Cliente
   ↓
API Management
   ↓
Backend API
```

---

# 🌐 Parte 6 - Developer Portal

## 🧠 Objetivo

Explorar el portal para desarrolladores.

---

## 🔍 Qué mostrar

- documentación automática
- probar APIs
- suscripciones
- ejemplos de requests

---

# 💡 ¿Por qué es importante?

Facilita:
- onboarding de developers
- documentación
- consumo de APIs

---

# 📌 Conceptos importantes

| Funcionalidad | Objetivo |
|---------------|----------|
| Subscription Key | proteger APIs |
| Rate Limiting | limitar requests |
| Policies | modificar comportamiento |
| JWT Validation | autenticación |
| Developer Portal | documentación y consumo |

---

# 🔥 Conclusión

Azure API Management permite:

- centralizar APIs
- aplicar seguridad
- controlar tráfico
- modificar requests
- desacoplar clientes del backend

👉 Todo sin modificar la aplicación backend.

---

# 🗣️ Preguntas para la clase

- ¿Qué problema resuelve Rate Limiting?
- ¿Por qué usar Subscription Keys?
- ¿Qué ventajas tiene modificar headers desde APIM?
- ¿Qué beneficios tiene separar backend y gateway?