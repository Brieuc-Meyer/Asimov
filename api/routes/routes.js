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
routeur.get('/eleve/:eleve_id/notes', ctrlEleves.afficherNotesUnEleve)
routeur.get('/eleve/:eleve_id/moyennes', ctrlEleves.afficherMoyennesEleveParMatiere)

routeur.get('/professeur/:perso_id/voirEleves', ctrlProfesseurs.afficherElevesUnProf)
routeur.get('/professeur/ajouterEleve/:eleve_nom/:eleve_identifiant/:eleve_mdp/:eleve_class_grade', ctrlProfesseurs.ajouterEleve)
routeur.get('/professeur/voirModifEleve/:eleve_id', ctrlProfesseurs.afficherModifEleve)
routeur.get('/professeur/modifEleve/:eleve_nom/:eleve_identifiant/:eleve_mdp/:eleve_class_grade/:eleve_id', ctrlProfesseurs.modifEleve)
routeur.get('/professeur/supprimerEleve/:eleve_id', ctrlProfesseurs.supprimerEleve)
routeur.get('/professeur/afficherClassesProf/:perso_id', ctrlProfesseurs.afficherClassesProf)


routeur.get('/professeur/voirNotesUnEleve/:eleve_id', ctrlProfesseurs.afficherNotesUnEleve)
routeur.get('/professeur/ajouterNote/:note_eleve_id/:note_pourcent/:note_prof_id/:note_mat_id/:note_date_evaluation/:note_intitule/:note_description', ctrlProfesseurs.ajouterNote)
routeur.get('/professeur/voirModifEleve/:eleve_id', ctrlProfesseurs.afficherModifEleve)
routeur.get('/professeur/modifEleve/:eleve_nom/:eleve_identifiant/:eleve_mdp/:eleve_class_grade', ctrlProfesseurs.modifEleve)
routeur.get('/professeur/supprimerEleve/:eleve_id', ctrlProfesseurs.supprimerEleve)


module.exports = routeur;