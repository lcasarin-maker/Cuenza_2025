# PLAN.md — Cuenza 2025 Legacy v0.5 (CoderCerberus)

**Versión:** 0.5 (Legacy)  
**Protocolo:** CoderCerberus v0.5  
**Mandato:** B10 (Checkpointing) + Audit Scope  
**Escrito:** 2026-06-02

---

## STATUS ACTUAL

**LEGACY ARCHIVE:**
- ✅ 50+ páginas ASP.NET VB
- ✅ Facturación crítica (CFDI generation)
- ✅ Bitácora de auditoría presente
- ⚠️ ZERO DEVELOPMENT (read-only)

---

## ANGRY PATHS — RIESGOS IDENTIFICADOS (S3 Bio-Containment)

### 🔴 Path 1: SQL Injection in VB.NET
**Escenario:** Queries construidas con concatenación string sin parametrización.
```vb
' VULNERABLE (ejemplo):
Dim query = "SELECT * FROM Clientes WHERE ID = " & clienteID
```

**Mitigación Requerida:**
- Auditar Facturacion.aspx.vb (linea crítica)
- Buscar patrones: `"SELECT * FROM"` sin SqlParameter
- **Action:** DOCUMENT (no fix, legacy read-only)

### 🔴 Path 2: Missing Audit Log Entries
**Escenario:** FacturacionGenerar.aspx no registra timbrado en Bitácora.
**Impacto:** Imposible auditar CFDIs generados; compliance FAIL.

**Mitigación Requerida:**
- Verificar Bitacora.aspx coverage
- Log DEBE incluir: timestamp, usuario, CFDI ID, monto

### 🔴 Path 3: No Input Validation Before DB Write
**Escenario:** Form inputs directos sin validación; nulls, tipo incorrecto.
**Impacto:** Data corruption en Clientes/Empresas.

**Mitigación Requerida:**
- Auditar cada .aspx.vb para validators
- **Action:** DOCUMENT (legacy maintenance mode)

---

## AUDITORÍA REQUERIDA (S3 + S9)

| Archivo | Auditar | Hallazgo |
|---------|---------|----------|
| Facturacion.aspx.vb | SQL injection risk | PENDING |
| Bitacora.aspx.vb | Logging completeness | PENDING |
| ControlCobranza.aspx.vb | Input validation | PENDING |

---

## ACCIÓN FINAL

**Status:** 🟡 **LEGACY ARCHIVE — MAINTENANCE ONLY**

- ✅ Documentado bajo CoderCerberus v0.5
- ✅ Riesgos identificados (S3, S9)
- ⚠️ **NO FIXES** (read-only archive)
- 📋 **Audit trail requerida** para compliance

**Recomendación:**
Migrar crítica Facturación a sistema moderno dentro de 12 meses.
Mantener legacy solo como reference/fallback.

---

**Status:** 🟡 PLAN ARCHIVADO (Legacy Maintenance)  
**Auditor:** Claude (CoderCerberus v0.5)  
**Fecha:** 2026-06-02
