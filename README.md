# La Caja

Bienvenidos al repositorio oficial de **La Caja**, un proyecto colaborativo desarrollado en Unity.
Este documento explica cómo colaborar, mantener el orden y compartir avances fácilmente, incluso si no usás Git o GitHub.

---

## 🚦 Pautas del Proyecto

Este repositorio es la versión oficial y estable del proyecto. Es mantenida por el coordinador (Juan).

## 🚀 ¿Qué necesitamos?

### Para abrir el proyecto:
🔹 Unity Hub (https://unity.com/unity-hub)
🔹 Editor version 6000.1.11f1
🔹 Git + Git LFS (solo si vas a usar Git)
🔹 Este repositorio: (https://github.com/juanignaciojuan/la-caja)

---

## 📁 Estructura del Proyecto

Mantener la organización dentro de la carpeta:

Assets/
├── Arte/
├── Audio/
├── Escenas/
├── Modelos/
├── Prefabs/
├── UI/
└── Scripts/

### 🧠 Si sos parte del equipo (diseño, audio, arte, narrativa):

- No es necesario que uses GitHub.
- Podés trabajar los assets localmente y enviarlos a Juan para su integración.

1. 🎨 Trabajá en tus archivos como prefieras (Blender, Photoshop, Illustrator, DAW, etc).
2. 📂 Organizá los archivos en carpetas:  
   Ejemplo:  /Audio/ambientes/ruinas_loop_01.wav
3. 📝 Agregá un archivo de texto si necesitás explicar qué hiciste o cómo usarlo.
4. 🚚 Enviá tus archivos por Google Drive o por mail a Juan.

**Yo (Juan)** me encargo de agregar tus cambios al proyecto oficial y mantener todo organizado.

### 🧳 Cómo enviar tus avances?

Export as `.unitypackage`:
1. En Unity, botón derecho a tus archivos o carpetas (como Prefabs, Models, etc.)
2. Seleccioná `Export Package...` (✅ include dependencies)
3. Nombralo claramente (por ejemplo, `environment-props-v2.unitypackage`)
4. Envialo por Google Drive (https://drive.google.com/drive/folders/1ulJZbWsvYNMcb7rE0yE-O7Vr9DFeMjEU?usp=drive_link)

### 💡 Notas a los miembros del equipo

- No modificar `Assets/Scenes/MainScene.unity` directamente.
- Agregá tus iniciales o tu nombre a los archivos que creás (por ejemplo, `Radio_Gabriela.prefab`)
- Para evitar conflictos, solamente Juan va a actualizar los cambios (commit updates) a este repositorio.
- Obviamente, si necesitás experimentar algo podés hacerlo en otro proyecto en Unity.

---

### 🔐 Reglas de Git (dev)

- Solamente Juan actualiza el `main` (pushes to main) y administra las ramas (branches).
- Git LFS está activado para los archivos pesados (.fbx, .png, .wav, etc.)

