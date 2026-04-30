# 🧪 Ejercicio - Lifecycle Management y Access Tiers en Blob Storage

## 🎯 Objetivo

- Comprender los niveles de acceso (Hot, Cool, Archive)
- Aplicar reglas de ciclo de vida en Azure Storage
- Optimizar costos de almacenamiento automáticamente

---

## 🧠 Escenario

Tienes una aplicación que guarda archivos en Azure Blob Storage:

- Archivos nuevos → se acceden frecuentemente
- Archivos después de 30 días → se acceden poco
- Archivos después de 90 días → casi no se acceden

👉 Necesitas optimizar costos automáticamente

---

## 🛠️ Parte 1 - Crear entorno

1. Crear una Storage Account
2. Crear un container llamado `data`
3. Subir al menos 2 archivos (ej: imagen, PDF)

---

## 🔥 Parte 2 - Configurar Access Tier manual

1. Ir al container
2. Seleccionar un blob
3. Cambiar el Access Tier:

- primero a **Hot**
- luego a **Cool**

👉 Observar:
- opciones disponibles
- cambios en el portal

---

## 🔄 Parte 3 - Configurar Lifecycle Management

1. Ir a:
   - Storage Account → Lifecycle Management

2. Crear una nueva regla:

### Regla:

- Nombre: `lifecycle-rule`
- Scope: All blobs
- Filtros: ninguno

### Acciones:

- Mover a Cool después de **30 días**
- Mover a Archive después de **90 días**

---

## 🔍 Parte 4 - Análisis

Responder:

- ¿Qué ventaja tiene usar lifecycle management?
- ¿Qué pasa si un archivo está en Archive y quiero usarlo?
- ¿Qué tipo de datos pondrías en cada tier?

---

## ⚠️ Importante

- Archive no permite acceso inmediato
- Tiene costo de recuperación
- No es ideal para datos activos

---

## 🚀 Bonus (opcional)

Crear una regla adicional:

- Eliminar blobs después de 180 días

👉 ¿En qué escenario usarías esto?

---
## Ver Precios

https://azure.microsoft.com/en-us/pricing/details/storage/blobs/

## 📌 Conclusión

- Azure permite optimizar costos automáticamente
- Los access tiers son clave para decisiones de arquitectura
- Lifecycle management evita gestión manual