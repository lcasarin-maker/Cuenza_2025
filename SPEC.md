# SPEC.md — Cuenza 2025 Legacy v0.5

**Versión:** 0.5 (Legacy Archive)  
**Protocolo:** CoderCerberus v0.5  
**Status:** MAINTENANCE MODE — READ-ONLY  
**Escrito:** 2026-06-02

---

## DESCRIPCIÓN OPERACIONAL

Sistema legacy de gestión integral para despacho jurídico:

### Módulos Principales
1. **Gestión de Clientes** (Clientes.aspx / ClientesAgregar.aspx)
   - Registro de clientes, contactos, datos fiscales
   - Base de datos: SQLServer (legacy)

2. **Gestión de Empresas** (Empresas.aspx / EmpresasAgregar.aspx)
   - Registro de empresas, sucursales
   - Integración con facturación

3. **Facturación** (Facturacion.aspx, FacturacionCancelar.aspx, FacturacionCargaBatch.aspx)
   - **CRÍTICA:** Generación de CFDIs, timbrado
   - Integración con SAT (Servicio de Administración Tributaria)
   - Base de datos: SQLServer

4. **Bitacora** (Bitacora.aspx)
   - Auditoría de cambios
   - Log de accesos y operaciones

5. **Control de Cobranza** (ControlCobranza.aspx)
   - Seguimiento de pagos
   - Reportes financieros

### Arquitectura
- **Frontend:** ASP.NET WebForms (.aspx, .aspx.vb)
- **Backend:** VB.NET
- **Database:** SQLServer
- **Runtime:** .NET Framework 4.5
- **Status:** LEGACY (maintenance only, no new features)

---

## MANDATOS APLICABLES

| Mandato | Status | Notas |
|---------|--------|-------|
| S3 | ⚠️ AUDIT | Bio-Containment: SQL queries sin parametrización (riesgo) |
| S5 | ⚠️ AUDIT | Anti-Slop: verificar warnings en compilación VB |
| S9 | ✅ PRESENTE | Logging: Bitacora.aspx existe pero incompletitud detectada |
| B2 | ✅ CUMPLE | SPEC.md presente (este archivo) |
| B10 | ✅ CUMPLE | PLAN.md documentado con estado legacy |

---

## PRÓXIMOS PASOS

**NO HAY DESARROLLO.**  
Solo mantenimiento y auditoría de seguridad.

---

**Status:** 🟡 LEGACY ARCHIVE — AUDIT REQUIRED  
**Auditor:** Claude (CoderCerberus v0.5)  
**Fecha:** 2026-06-02
