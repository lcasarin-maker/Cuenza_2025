# Legacy Quenza

Este directorio contiene el sistema legacy original de Quenza como proyecto independiente de referencia y operación histórica.

## Estructura

- `Login.aspx`, `MasterPageCuenza.Master` y las páginas WebForms: superficie legacy principal.
- `Bin/`: binarios compilados del legacy.
- `Ficheros/`, `Imagenes/`, `Plantillas/`, `Skin/`: recursos y evidencia del sistema original.
- `Web.config`: configuración de arranque y conexiones del legacy.
- `CPAdmin 2026 05 04.bak`: respaldo de la base histórica.

## Cómo arrancarlo

Usa el script raíz del repo:
```powershell
.\run-legacy.ps1
```

O los accesos directos:
- `Correr-Legacy-Cuenza.cmd`
- `Parar-Legacy-Cuenza.cmd`

## Qué pertenece aquí

- Código y markup WebForms original.
- DLLs y binarios legacy.
- Configuración y respaldo del entorno histórico.
- Evidencia operativa del sistema original.

## Qué no pertenece aquí

- Código moderno del proyecto activo.
- Contratos de Cerberus o documentación del protocolo moderno.
- Scripts de automatización del árbol moderno que no sean necesarios para el arranque legacy.

## Notas

- Este legacy puede operar por sí mismo, pero depende de su entorno: IIS Express, SQL Server y el backup restaurado.
- Trátalo como una frontera distinta al moderno, no como una carpeta auxiliar del mismo proyecto.
