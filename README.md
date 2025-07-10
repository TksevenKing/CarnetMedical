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
- `App_Data/` : (optionnel) base locale pour tests
- `web.config` : Configuration + chaînes de connexion

---

## 🧪 Démonstration rapide (optionnel si tu as une vidéo ou capture)

> ![screenshot](./assets/demo.png)

---

## 🧾 Base de données

Tu peux retrouver le script de création dans ce dépôt :  
📄 `MediCard_Script_BaseDeDonnees.sql`

---

## 📦 Déploiement local (IIS)

1. Publier le projet dans un dossier (`C:\inetpub\wwwroot\MediCard`)
2. Lancer **IIS Manager**
3. Ajouter un site (`localhost/MediCard`)
4. Configurer les droits (IIS_IUSRS)
5. Lancer via `http://localhost/MediCard/`

---

## 🙋‍♂️ Auteur

**Oumar** – Étudiant en informatique – Passionné par les solutions utiles & concrètes  
📧 Contact : oumar@email.com *(remplace avec ton vrai contact)*

---

## 📄 Licence

Ce projet est open-source et peut être utilisé dans un but éducatif.

