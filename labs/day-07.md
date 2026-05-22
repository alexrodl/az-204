# 🧪 Día 07 - Azure Key Vault y App Configuration

## 🎯 Objetivos

- Entender qué es Azure Key Vault
- Administrar secretos y certificados
- Comprender buenas prácticas de seguridad
- Entender qué es Azure App Configuration
- Centralizar configuración de aplicaciones
- Integrar configuración y secretos en aplicaciones

---

# 🧠 Conceptos clave

- Secrets
- Keys
- Certificates
- Configuration
- Centralized configuration
- Managed Identity

---

# 🧩 Introducción

Las aplicaciones modernas necesitan:

- manejar secretos
- almacenar configuración
- evitar credenciales hardcodeadas
- centralizar configuración entre ambientes

👉 Azure Key Vault y App Configuration ayudan a resolver estos problemas.

---

# Laboratorios
Xlabs: [AZ-204T00-A-AZH-CEP-M09A] Create and retrieve secrets from Azure Key Vault

[Azure Key Vault](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-secure-solutions/01-key-vault-store-retrieve.html)

Xlabs: [AZ-204T00-A-AZH-CEP-M09B] Retrieve configuration settings from Azure App Configuration

[Azure App Configuration](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-secure-solutions/02-app-config-retrieve.html)

---

# 🔐 Azure Key Vault

## 🧠 ¿Qué es?

Azure Key Vault es un servicio seguro para almacenar:

- secretos
- claves
- certificados

---

# 🎯 ¿Para qué se usa?

- connection strings
- passwords
- API keys
- certificados SSL
- secretos de aplicaciones

---

# ⚠️ Problema que resuelve

❌ No guardar secretos en:
- código fuente
- appsettings.json
- GitHub

---

# 🔥 Tipos de objetos

## 🔹 Secrets
Valores sensibles.

👉 Ejemplo:
- passwords
- tokens
- connection strings

---

## 🔹 Keys
Claves criptográficas.

👉 Ejemplo:
- cifrado
- firmas digitales

---

## 🔹 Certificates
Certificados digitales.

👉 Ejemplo:
- HTTPS/SSL

---

# 🔒 Soft-delete y Purge Protection en Azure Key Vault

## 🧠 Soft-delete

Soft-delete permite recuperar un Key Vault o secretos eliminados accidentalmente.

👉 Cuando un recurso se elimina:
- no desaparece inmediatamente
- queda retenido durante un período configurable

---

## 📅 Days to retain deleted vaults

Define la cantidad de días que el Key Vault permanecerá recuperable después de ser eliminado.

👉 Ejemplo:
- 7 días
- 30 días
- 90 días

Durante ese período:
- el recurso puede restaurarse
- el nombre del vault sigue reservado

---

## 🛡️ Purge Protection

Purge Protection evita la eliminación permanente inmediata de un Key Vault o sus secretos.

👉 Incluso usuarios administradores no pueden purgar el recurso hasta finalizar el período de retención.

---

# ⚠️ ¿Por qué es importante?

Ayuda a proteger contra:
- eliminaciones accidentales
- errores administrativos
- ataques maliciosos

---

# 📌 Resumen

| Funcionalidad | Objetivo |
|---------------|----------|
| Soft-delete | Recuperar recursos eliminados |
| Retention Days | Tiempo de recuperación disponible |
| Purge Protection | Evitar eliminación permanente inmediata |

# 🖥️ Demo (Portal)

Crear:

- Key Vault
- Secret
- Leer valor del secret

---

# 🔒 Seguridad

## 🔹 Access Policies / RBAC

Definen quién puede acceder al Key Vault.

---

## 🔹 Managed Identity

Permite que aplicaciones accedan a Key Vault sin guardar credenciales.

👉 Recomendado en Azure.

---

# 💡 Ejemplo conceptual

```text
Aplicación
    ↓
Managed Identity
    ↓
Key Vault
    ↓
Secret
```

---

# ⚠️ Importante

👉 Nunca exponer secretos públicamente.

---

# 🌐 Azure App Configuration

## 🧠 ¿Qué es?

Servicio para centralizar configuración de aplicaciones.

---

# 🎯 ¿Para qué se usa?

- feature flags
- configuración por ambiente
- parámetros compartidos
- configuración dinámica

---

# 💡 Ejemplos

- color del sitio
- endpoints
- configuración de APIs
- habilitar/deshabilitar funcionalidades

---

# ⚙️ Ventajas

- configuración centralizada
- cambios sin redeploy
- integración con Azure

---

# 🖥️ Demo (Portal)

Crear:

- App Configuration
- Key-value
- Feature Flag

---

# 🚩 Feature Flags

## 🧠 ¿Qué son?

Permiten activar o desactivar funcionalidades dinámicamente.

---

# Tipos de Feature Flags en Azure App Configuration

## Switch

Feature flag básico tipo ON/OFF.

### Uso
- Habilitar o deshabilitar funcionalidades
- Kill switch
- Features beta

### Ejemplo
```txt
EnableNewDashboard = true
```

### Cuándo usarlo
- Aplicaciones pequeñas
- MVPs
- Features simples
- Demos

---

## Rollout

Permite habilitar funcionalidades gradualmente.

### Uso
- Canary deployments
- Releases progresivos
- Reducir riesgo en producción

### Ejemplo
- 10% de usuarios
- 25% de usuarios
- 100% de usuarios

### Cuándo usarlo
- Producción
- Aplicaciones enterprise
- Nuevas funcionalidades críticas

---

## Experiment

Pensado para A/B Testing y experimentación.

### Uso
- Comparar versiones
- Medir comportamiento usuarios
- Analytics y optimización

### Ejemplo
- Botón azul vs verde
- Dos versiones de UI

### Cuándo usarlo
- Productos grandes
- Equipos de producto
- Aplicaciones orientadas a métricas

---

# Resumen

| Tipo | Objetivo |
|---|---|
| Switch | Encender o apagar features |
| Rollout | Liberar features gradualmente |
| Experiment | Probar y medir resultados |


---

# 🔥 Integración Key Vault + App Configuration

## 🧠 Escenario recomendado

- App Configuration → configuración general
- Key Vault → secretos

---

# 💡 Ejemplo

## App Configuration

```text
ApiUrl=https://api.company.com
```

---

## Key Vault

```text
DatabasePassword=*****
```

---

# ⚖️ Diferencia entre ambos servicios

| Servicio | Uso principal |
|----------|---------------|
| Key Vault | secretos y seguridad |
| App Configuration | configuración de aplicaciones |

---

# 🧪 Laboratorio

## Objetivo

- Crear Key Vault
- Crear secrets
- Crear App Configuration
- Leer configuración desde Azure

---

# 🔥 Conceptos importantes

## 🔹 Secret Rotation
Permite cambiar secretos periódicamente.

---

## 🔹 Centralized Configuration
Múltiples aplicaciones usando la misma configuración.

---

## 🔹 Environment Configuration
Configuraciones distintas según:
- dev
- test
- prod

---

# ⚠️ Notas importantes

- No almacenar secretos en App Configuration
- Usar Key Vault para información sensible
- Aplicar principio de mínimo privilegio

---

# 📌 Resumen

- Key Vault protege información sensible
- App Configuration centraliza configuración
- Feature Flags permiten cambios dinámicos
- Managed Identity evita guardar credenciales
- Ambos servicios suelen utilizarse juntos

---

# 🗣️ Preguntas para la clase

- ¿Por qué es peligroso guardar secretos en código?
- ¿Qué ventajas tiene centralizar configuración?
- ¿Cuándo usarían Feature Flags?
- ¿Por qué Managed Identity es importante?

---

# 🔄 Próximos pasos

En la próxima clase veremos:

- Azure API Management
- Publicación y protección de APIs