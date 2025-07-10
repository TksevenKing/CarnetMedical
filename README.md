# 🩺 MediCard – Carnet Médical Personnel en Ligne

MediCard est une application Web ASP.NET Web Forms (C#) qui permet à chaque patient de gérer son carnet médical, ses documents de santé et ses relations avec des docteurs, de manière sécurisée et centralisée.

---

## 📌 Problème rencontré

Au Maroc, l'assurance exige l'envoi des dossiers médicaux originaux (ordonnances, radios, etc.) pour tout remboursement. Une fois envoyés, ces documents deviennent inaccessibles pour de futures consultations. MediCard est né de cette contrainte réelle vécue personnellement.

---

## 🚀 Fonctionnalités principales

- 🔐 Authentification sécurisée par mot de passe haché (SHA256)
- 📋 Création, modification, suppression du carnet médical en ligne
- 📂 Téléversement de documents médicaux scannés (PDF)
- 👨‍⚕️ Attribution d’accès à un ou plusieurs docteurs enregistrés
- 📚 Historique automatique des modifications
- 📄 Export PDF du carnet
- 🧑‍💼 Interface administrateur (gestion des utilisateurs et docteurs)
- 🖥️ Design responsive avec Bootstrap 5

---

## 🧰 Technologies utilisées

| Technologie       | Usage                            |
|-------------------|----------------------------------|
| ASP.NET Web Forms | Backend & logique métier         |
| C#                | Code-behind et traitement        |
| SQL Server        | Base de données relationnelle    |
| Bootstrap 5       | UI responsive                    |
| iTextSharp        | Export PDF                       |
| IIS (local)       | Déploiement local Windows        |

---

## 🏗️ Structure du projet

- `CarnetMedical/` : Pages ASPX, code-behind et logique
- `App_Code/` : Classes partagées
- `Scripts/` et `Content/` : JS / CSS / Bootstrap
- `web.config` : Configuration + chaînes de connexion

---

## 🧪 Démonstration rapide 

<img width="1366" height="768" alt="Capture d’écran (180)" src="https://github.com/user-attachments/assets/86accaa1-e539-4ff7-93fc-05ad996ec9e0" />
<img width="1366" height="768" alt="Capture d’écran (196)" src="https://github.com/user-attachments/assets/9f9058b1-b656-4fdd-b44b-f775a529b012" />
<img width="1366" height="768" alt="Capture d’écran (204)" src="https://github.com/user-attachments/assets/23b9c0c8-4ae0-4556-b514-42c3ed107d2b" />
<img width="1366" height="768" alt="Capture d’écran (192)" src="https://github.com/user-attachments/assets/64364b21-d2fa-40f6-a168-4a8ed2a0071c" />
<img width="1366" height="768" alt="Capture d’écran (193)" src="https://github.com/user-attachments/assets/941fccc1-1195-4d17-b930-88ccde5f4bc2" />
<img width="1366" height="768" alt="Capture d’écran (194)" src="https://github.com/user-attachments/assets/1cb823b4-2f32-4958-93ec-a27350f7bafc" />
<img width="1366" height="768" alt="Capture d’écran (195)" src="https://github.com/user-attachments/assets/24aa7637-c10f-4288-88d1-d52913d68c6d" />


---



## 📦 Déploiement local (IIS)

1. Publier le projet dans un dossier (`C:\inetpub\wwwroot\MediCard`)
2. Lancer **IIS Manager**
3. Ajouter un site (`localhost/MediCard`)
4. Configurer les droits (IIS_IUSRS)
5. Lancer via `http://localhost/MediCard/`

---

## 🙋‍♂️ Auteur

**OumarKingDev** – Étudiant en informatique – Passionné par les solutions utiles & concrètes  
📧 Contact : oumarciss300@gmail.com 

---

## 📄 Licence

Ce projet est open-source et peut être utilisé dans un but éducatif.

