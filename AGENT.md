# AGENT.md — Cuenza 2025 Legacy v0.5

**Versión canónica:** `v0.5`  
**Protocolo:** CoderCerberus v0.5  
**Status:** MAINTENANCE MODE — Live Legacy System

---

## Propósito

Sistema legacy de gestión integral para despacho jurídico. Gestión de clientes, empresas, facturación con CFDIs integrados a SAT.

**¡IMPORTANTE!** Este es un proyecto en MAINTENANCE MODE:
- No agregar features nuevas sin coordinación
- Solo bugfixes y parches críticos
- Roadmap: Migración a .NET 6+ en Sprint 2+
- Documentación completa en SPEC.md

---

## Arranque Mínimo

1. **Leer `SPEC.md`** (líneas 1-50, 2 min)
   - Módulos principales
   - Estructura de BD (SQLServer)
   - Status de cada componente

2. **Leer `PLAN.md`** (líneas 1-40, 2 min)
   - Roadmap de modernización
   - Angry Paths (3 fallos documentados)
   - Sprint-based timeline

3. **Leer `HISTORIAL.md`**
   - Cambios recientes
   - Problemas conocidos

4. **Validar paridad de versión:**
   - `.agent_state.json = v0.5` (check)
   - Binding CoderCerberus v0.5 activo

---

## Mandatos Activos (v0.5)

### SYSTEM-TIER
```
S3: Bio-Containment        → SQL injection vectors auditados
S4: Modularidad            → VB.NET modules → DLLs (Sprint 2+)
S5: Anti-Slop              → Compilation warnings → errors
S9: Logging Estructurado   → Bitacora.aspx expandido
S17: Paridad Versión       → v0.5 sincronizado
```

### BEHAVIOR-TIER
```
B2: Brain-First            → SPEC.md + PLAN.md documentado
B3: Angry Path             → 3 fallos en PLAN.md
B10: Checkpointing         → Sprint-based roadmap
```

---

## Estructura Crítica

```
cuenza_2025/
├── SPEC.md                → [LEER PRIMERO] Especificación completa
├── PLAN.md                → Roadmap + Angry Paths
├── .agent_state.json      → v0.5
├── SQLServer/
│   └── [esquemas legacy]
├── VB.NET/
│   ├── Clientes/
│   ├── Empresas/
│   ├── Facturacion/       → CRÍTICA (CFDIs + SAT)
│   └── Bitacora/
└── Roadmap Sprint 2+      → Modernización .NET 6
```

---

## Antes de Cualquier Cambio

1. ✅ **git status** — Verificar rama limpia
2. ✅ **SPEC.md** — Leer descripción operacional
3. ✅ **PLAN.md** — Revisar roadmap + angry paths
4. ✅ **Coordinar** — Con owner antes de cambios

---

## Contacto / Owner

**Status:** MAINTENANCE MODE  
**Lenguaje:** VB.NET (legacy) → .NET 6+ (roadmap)  
**BD:** SQLServer (migrando a PostgreSQL)  
**Última actualización:** 2026-06-02

**⚠️ NOTA:** Este proyecto es legacy. Cualquier nueva arquitectura debe alinearse con CoderCerberus v0.5 y PLAN.md Sprint roadmap.
