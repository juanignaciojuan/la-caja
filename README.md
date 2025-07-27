# La Caja

Bienvenidos al repositorio oficial de **La Caja**.
Este documento explica cómo colaborar, mantener el orden y compartir avances fácilmente, incluso si no usás Git o GitHub.

---

## 🚦 Pautas del Proyecto

Este repositorio es la versión oficial y estable del proyecto.

### 🛠️ Requisitos previos

| Herramienta                 | Enlace de descarga                                 |
|-----------------------------|----------------------------------------------------|
| Git                         | https://git-scm.com/downloads                      |
| Git LFS                     | https://git-lfs.com/                               |
| Unity Hub                   | https://unity.com/download                         |
| Unity Editor (6000.1.11f1)  | Desde Unity Hub                                    |
| Visual Studio (opcional)    | https://visualstudio.microsoft.com/es/downloads/   |

---

### 🧭 Pasos para abrir el proyecto correctamente

1. **Instalar Git**

   _**En mac**_
   _abrís una terminal (cmd + barra espaciadora)_
   git --version
   _le das a enter_

2. **Instalar Git LFS**
   _**En Windows:**_
   _abrís una terminal (cmd) y escribís:_
   git lfs install
   _le das a enter_

   _**En mac**_
   _abrís una terminal (cmd + barra espaciadora)_
   git lfs install
   _le das a enter_

4. **Clonar el repositorio**

   _**En Windows**_
   _primero navegás a la carpeta dedicada escribiendo en la terminal:_
   cd ubicacion\de\la\carpeta
   git clone https://github.com/juanignaciojuan/la-caja.git
   _le das a enter_

   _**En mac**_
   _primero navegás a la carpeta dedicada escribiendo en la terminal:_
   cd ~/ubicacion/de/la/carpeta
   git clone https://github.com/juanignaciojuan/la-caja.git
   _le das a enter_

5. **Descargar los archivos grandes (texturas, sonidos, modelos, etc.)**
   _escribís en la terminal:_
   git lfs pull
   _le das a enter_

6. **Abrir el proyecto en Unity**
   Ir a Unity Hub > Add project from disk
   Seleccionar la carpeta _la-caja_

---

## 📁 Estructura del Proyecto

Mantener la organización dentro de la carpeta:

la-caja/
├── Assets/
│   ├── Art/
│   ├── Audio/
│   ├── Scenes/
│   ├── Prefabs/
│   └── Scripts/
├── ProjectSettings/
├── Packages/
├── README.md
├── .gitignore
├── .gitattributes

### 🧠  No es necesario usar GitHub. Podés trabajar los assets localmente.:

1. 🎨 Trabajá en tus archivos como prefieras (Blender, Photoshop, Illustrator, DAW, etc).
2. 📂 Organizá los archivos en carpetas:  
   Ejemplo:  /Audio/ambientes/ruinas_loop_01.wav
3. 📝 Agregá un archivo de texto si necesitás explicar qué hiciste o cómo usarlo.
4. 🚚 Enviá tus archivos por Google Drive (https://drive.google.com/drive/folders/1dEdXM6VfwY3aRlNf3ypusnU06A47kAm-?usp=drive_link)

### 🧳 ¿Cómo enviar tus avances en Unity?

Export as `.unitypackage`:
1. En Unity, botón derecho a tus archivos o carpetas (como Prefabs, Models, etc.)
2. Seleccioná `Export Package...` (✅ include dependencies)
3. Nombralo claramente (por ejemplo, `environment-props-v2.unitypackage`)
4. Envialo por Google Drive (https://drive.google.com/drive/folders/1SIASrEZ_HWh_YSKwI7737ClLEjfELuWa?usp=drive_link)

### 💡 Importante

- No modificar `Assets/Scenes/MainScene.unity` directamente.
- Agregá tus iniciales o tu nombre a los archivos que creás (por ejemplo, `Radio_Gabriela.prefab`)
- Para evitar conflictos, yo me ocupo de actualizar los cambios (commit updates) a este repositorio.
