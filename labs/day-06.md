# 🧪 Día 06 - Microsoft Entra ID, App Registration y Authentication

## 🎯 Objetivos

- Entender qué es Microsoft Entra ID
- Comprender autenticación y autorización
- Crear una App Registration
- Conocer permisos y consentimientos
- Introducir Microsoft Graph
- Consumir información de Microsoft Graph

---

# 🧠 Conceptos clave

- Identity
- Authentication
- Authorization
- Microsoft Entra ID
- App Registration 
- Access Token
- Microsoft Graph

---

# 🧩 Introducción

Las aplicaciones modernas necesitan:

- autenticar usuarios
- acceder a recursos protegidos
- integrarse con servicios de Microsoft

👉 Microsoft Entra ID permite resolver estos escenarios.

---

# Laboratorios

## App Registration

Xlabs: [AZ-204T00-A-AZH-CEP-M02A] Implement interactive authentication with MSAL.NET

https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-app-auth/01-msal-interactive-auth.html

## Microsoft Graph

Xlabs: [AZ-204T00-A-AZH-CEP-M02B] Retrieve user profile information with the Microsoft Graph SDK

https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-app-auth/02-graph-user-profile.html


# 🔐 ¿Qué es Microsoft Entra ID?

Microsoft Entra ID (antes Azure Active Directory) es el servicio de identidad de Microsoft.

👉 Permite:

- login de usuarios
- control de acceso
- autenticación de aplicaciones
- integración con Microsoft 365 y Azure

---

# 🎯 Casos de uso

- Login corporativo
- Single Sign-On (SSO)
- APIs protegidas
- Integración con Microsoft 365

---

# 🔑 Authentication vs Authorization

| Concepto | Significado |
|----------|-------------|
| Authentication | Verificar quién eres |
| Authorization | Definir qué puedes hacer |

---

## 💡 Ejemplo

### Authentication
👉 Usuario inicia sesión con email/password.

---

### Authorization
👉 Determinar si puede acceder a:
- APIs
- archivos
- recursos

---

# 🔥 Tokens

Cuando un usuario se autentica correctamente:

👉 Entra ID genera un Access Token.

---

## 🧠 ¿Qué contiene?

- identidad del usuario
- permisos
- información de la aplicación

---

# 📦 App Registration

## 🧠 ¿Qué es?

Una App Registration representa una aplicación dentro de Entra ID.

👉 Permite:
- autenticar usuarios
- solicitar tokens
- consumir APIs protegidas

---

# 🖥️ Demo (Portal)

Crear una App Registration:

- Name
- Supported account types
- Redirect URI

---

# 🔑 Datos importantes

Después de crear la App Registration:

👉 Obtener:

- Application (client) ID
- Directory (tenant) ID

---

# 🔐 Client Secret

## 🧠 ¿Qué es?

Credencial utilizada por aplicaciones para autenticarse.

👉 Similar a una contraseña de aplicación.

---

# ⚠️ Importante

- Guardar el secret
- No subirlo a GitHub
- Usar Azure Key Vault en producción

---

# 🔒 Permisos API

## 🧠 ¿Qué son?

Definen qué recursos puede acceder la aplicación.

---

## 💡 Ejemplos

- Leer perfil del usuario
- Leer emails
- Acceder a calendarios

---

# ⚠️ Consentimiento

Algunos permisos requieren:

- admin consent
- consentimiento del usuario

---

# 🌐 Microsoft Graph

## 🧠 ¿Qué es?

API unificada de Microsoft para acceder a:

- usuarios
- grupos
- emails
- calendarios
- archivos
- Teams

---

# 🎯 Casos de uso

- obtener perfil de usuario
- leer calendario
- automatizar tareas de Microsoft 365

---

# 💡 Ejemplo conceptual

```text
Aplicación
    ↓
Microsoft Graph
    ↓
Usuarios / Emails / Calendarios
```

---

# 🖥️ Demo (Graph Explorer)

Mostrar:

👉 https://developer.microsoft.com/graph/graph-explorer

Ejemplo:

```http
GET https://graph.microsoft.com/v1.0/me
```

---

# 🧪 Laboratorio

## Objetivo

- Crear App Registration
- Generar Client Secret
- Configurar permisos
- Consumir Microsoft Graph

---

# 🔥 Conceptos importantes

## 🔹 Tenant

Representa la organización/directorio de Entra ID.

---

## 🔹 Application ID

Identificador único de la aplicación.

---

## 🔹 Access Token

Token utilizado para acceder a APIs protegidas.

---

# 🔐 OAuth 2.0 y OpenID Connect

## 🧠 Introducción

Las aplicaciones modernas necesitan:

- autenticar usuarios
- acceder a recursos protegidos
- integrarse con proveedores de identidad

👉 OAuth 2.0 y OpenID Connect ayudan a resolver estos escenarios.

[View Information](https://learn.microsoft.com/en-us/entra/identity-platform/v2-oauth2-auth-code-flow)
---

# 🔑 OAuth 2.0

## 🧠 ¿Qué es?

OAuth 2.0 es un protocolo de autorización.

👉 Permite que una aplicación acceda a recursos protegidos en nombre de un usuario.

---

## 🎯 Objetivo principal

👉 Delegar acceso sin compartir credenciales.

---

## 💡 Ejemplo

Una aplicación quiere acceder al calendario de Microsoft 365.

👉 El usuario:
- inicia sesión
- acepta permisos

👉 La aplicación recibe un Access Token.

👉 La aplicación NUNCA ve la contraseña del usuario.

---

# 🔥 Conceptos importantes

## 🔹 Resource Owner
Usuario dueño de los datos.

---

## 🔹 Client
Aplicación que solicita acceso.

---

## 🔹 Authorization Server
Servidor que autentica al usuario.

👉 Ejemplo:
Microsoft Entra ID

---

## 🔹 Access Token
Token utilizado para acceder a recursos protegidos.

---

# 💡 Flujo simplificado

```text
Usuario
   ↓ login
Entra ID
   ↓ token
Aplicación
   ↓ token
API protegida
```

---

# ⚠️ Importante

OAuth NO fue diseñado para autenticación.

👉 Fue diseñado para autorización.

---

# 🪪 OpenID Connect (OIDC)

## 🧠 ¿Qué es?

OpenID Connect es una capa de autenticación construida sobre OAuth 2.0.

👉 Agrega identidad del usuario.

---

## 🎯 Objetivo principal

👉 Saber quién es el usuario autenticado.

---

# 💡 Ejemplo

Una aplicación permite:

```text
Login con Microsoft
```

👉 La aplicación necesita:
- autenticar usuario
- obtener información del perfil

---

# 🔥 ID Token

OpenID Connect introduce el:

👉 ID Token

---

## 🧠 ¿Qué contiene?

- nombre
- email
- identificador usuario
- claims

---

# ⚖️ OAuth vs OpenID Connect

| OAuth 2.0 | OpenID Connect |
|------------|----------------|
| Autorización | Autenticación |
| Access Token | ID Token |
| Acceso a APIs | Login de usuarios |

---

# 💡 Ejemplo práctico

## OAuth 2.0

👉 “La aplicación puede acceder a tu calendario.”

---

## OpenID Connect

👉 “La aplicación sabe quién eres.”

---

# 🔥 Relación entre ambos

👉 OpenID Connect usa OAuth 2.0 internamente.

---

# 📌 Resumen

- OAuth 2.0 → autorización
- OpenID Connect → autenticación
- Access Token → acceso a recursos
- ID Token → identidad del usuario
- Entra ID soporta ambos protocolos

---

# 🗣️ Preguntas para la clase

- ¿Por qué OAuth evita compartir contraseñas?
- ¿Qué diferencia hay entre Access Token e ID Token?
- ¿Cuándo usaríamos OpenID Connect?

# ⚠️ Notas importantes

- Nunca exponer Client Secrets
- Revisar permisos solicitados
- Seguir principio de mínimo privilegio

---

# 📌 Resumen

- Entra ID gestiona identidades y autenticación
- App Registration representa aplicaciones
- Authentication ≠ Authorization
- Microsoft Graph permite acceder a servicios Microsoft
- Los tokens permiten acceder a recursos protegidos

---

# 🗣️ Preguntas para la clase

- ¿Qué diferencia hay entre autenticación y autorización?
- ¿Para qué sirve una App Registration?
- ¿Qué tipo de información podría obtenerse con Microsoft Graph?
- ¿Por qué son importantes los permisos?

---

# 🔄 Próximos pasos

En la próxima clase veremos:

- Azure API Management
- Protección y publicación de APIs