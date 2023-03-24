const express = require('express');
const routeur = express.Router();


//relatives paths to 
const ctrlConnexion = require('../controllers/ctrlConnexion')
const ctrlEleves = require('../controllers/ctrlEleves')
const ctrlProfesseurs = require('../controllers/ctrlProfesseurs')
const ctrlProviseurs = require('../controllers/ctrlProviseurs')



//Toutes les routes dessous sont sécurisés par un middlware qui renvoie next() si l'user est euthentifié / à une session
//La Page d'aceuil
routeur.get('/connexionEleve/:eleve_identifiant/:eleve_mdp', ctrlConnexion.testConnexionEleves)
routeur.get('/connexionProfesseur/:perso_identifiant/:perso_mdp', ctrlConnexion.testConnexionPersonnels)


//Routes pour la page mutuelles
routeur.get('/eleve/:eleve_id/notes', ctrlConnexion.testAuthentification, ctrlEleves.afficherNotesUnEleve)

routeur.get('/professeur/:perso_id/voirEleves',ctrlConnexion.testAuthentification, ctrlProfesseurs.afficherElevesUnProf)
routeur.get('/professeur/ajouterEleve/:eleve_nom/:eleve_identifiant/:eleve_mdp/:eleve_class_grade', ctrlConnexion.testAuthentification, ctrlProfesseurs.ajouterEleve)
routeur.get('/professeur/voirModifEleve/:eleve_id', ctrlConnexion.testAuthentification, ctrlProfesseurs.afficherModifEleve)
routeur.get('/professeur/modifEleve/:eleve_nom/:eleve_identifiant/:eleve_mdp/:eleve_class_grade', ctrlConnexion.testAuthentification, ctrlProfesseurs.modifEleve)
routeur.get('/professeur/supprimerEleve/:eleve_id', ctrlConnexion.testAuthentification, ctrlProfesseurs.supprimerEleve)


routeur.get('/professeur/voirNotesUnEleve/:eleve_id',ctrlConnexion.testAuthentification, ctrlProfesseurs.afficherNotesUnEleve)
routeur.get('/professeur/ajouterNote/:note_eleve_id/:note_pourcent/:note_prof_id/:note_mat_id/:note_date_evaluation/:note_intitule/:note_description', ctrlConnexion.testAuthentification, ctrlProfesseurs.ajouterNote)
routeur.get('/professeur/voirModifEleve/:eleve_id', ctrlConnexion.testAuthentification, ctrlProfesseurs.afficherModifEleve)
routeur.get('/professeur/modifEleve/:eleve_nom/:eleve_identifiant/:eleve_mdp/:eleve_class_grade', ctrlConnexion.testAuthentification, ctrlProfesseurs.modifEleve)
routeur.get('/professeur/supprimerEleve/:eleve_id', ctrlConnexion.testAuthentification, ctrlProfesseurs.supprimerEleve)


module.exports = routeur;