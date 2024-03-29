/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
 * @Crédits : Lorenzo Porcu => aide sur les Promesses 
*/


//récuperer le module de connexion
let modelConnexion = require('./modelConnexion.js')
let mysqlConnexion = modelConnexion.mysqlConnexion

//export des methodes contenant les requettes SQL
module.exports = {

    /**
     * Médhodes d'instantiations des promesses de résultat de  @requetteSQL 
     * si @err est true la promesse est @return rejeté @reject avec le message d'erreur @err
     * sinon @return @resolve avec les donnés @data de la @requetteSQL
     * !  on ne peut résolve q'une @data par promesse  !
    */

    async modelAfficherElevesUnProf(req) {

        return new Promise((resolve, reject) => {
            let perso_id = req.params.perso_id
            //obligé de trier par classe car GROUP BY ne récupére pas certanis eleves
            let requeteSQL = `SELECT eleves.eleve_id, eleves.eleve_identifiant, eleves.eleve_mdp ,eleves.eleve_nom, classes.class_nom, classes.class_id
            FROM  eleves, liaison_personnel_classes, classes 
            WHERE liaison_personnel_classes.perso_id = ?
            AND eleves.eleve_class_id = classes.class_id 
            AND liaison_personnel_classes.class_id = eleves.eleve_class_id 
            ORDER BY eleve_class_id;`

            mysqlConnexion.query(requeteSQL, [perso_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },


    async modelAjouterEleve(req) {


        return new Promise((resolve, reject) => {

            let eleve_nom = req.params.eleve_nom
            let eleve_identifiant = req.params.eleve_identifiant
            let eleve_mdp = req.params.eleve_mdp
            let eleve_class_id = req.params.eleve_class_id

            let requeteSQL = "INSERT INTO eleves (eleve_nom, eleve_identifiant, eleve_mdp, eleve_class_id) VALUES (?, ?, ?, ?)"


            mysqlConnexion.query(requeteSQL, [eleve_nom, eleve_identifiant, eleve_mdp, eleve_class_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelSupprimerEleve(req) {


        return new Promise((resolve, reject) => {

            let eleve_id = req.params.eleve_id

            let requeteSQL = "DELETE FROM eleves WHERE eleve_id = ?;"


            mysqlConnexion.query(requeteSQL, [eleve_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },




    async modelmodifEleve(req) {



        return new Promise((resolve, reject) => {

            let eleve_nom = req.params.eleve_nom
            let eleve_identifiant = req.params.eleve_identifiant
            let eleve_mdp = req.params.eleve_mdp
            let eleve_class_id = req.params.eleve_class_id
            let eleve_id = req.params.eleve_id


            let requeteSQL = 'UPDATE eleves SET eleve_nom = ?, eleve_identifiant = ?, eleve_mdp = ?, eleve_class_id = ?  WHERE eleve_id = ?'
            mysqlConnexion.query(requeteSQL, [eleve_nom, eleve_identifiant, eleve_mdp, eleve_class_id, eleve_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
    // pour connaitre la matière de la note que le prof assigne
    async modelAfficherMatieresProf(req) {


        return new Promise((resolve, reject) => {
            let perso_id = req.params.perso_id

            let requeteSQL = `SELECT matieres.*
            FROM  matieres, liaison_personnel_matieres, personnels 
            WHERE liaison_personnel_matieres.perso_id = ?
            AND matieres.mat_id = liaison_personnel_matieres.mat_id 
            AND liaison_personnel_matieres.perso_id = personnels.perso_id;`

            mysqlConnexion.query(requeteSQL, [perso_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
    async modelAfficherMatieresLibresProf(req) {


        return new Promise((resolve, reject) => {
            let perso_id = req.params.perso_id

            let requeteSQL = `SELECT * 
                FROM matieres
                WHERE matieres.mat_id NOT IN(
                    SELECT liaison_personnel_matieres.mat_id
                    FROM  liaison_personnel_matieres 
                    WHERE liaison_personnel_matieres.perso_id = ?);`

            mysqlConnexion.query(requeteSQL, [perso_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelAfficherClassesProf(req) {


        return new Promise((resolve, reject) => {
            let perso_id = req.params.perso_id

            let requeteSQL = `SELECT classes.class_id, classes.class_nom
            FROM classes, liaison_personnel_classes
            WHERE liaison_personnel_classes.perso_id = ?
            AND liaison_personnel_classes.class_id = classes.class_id`

            mysqlConnexion.query(requeteSQL, [perso_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
    async modelAfficherClassesLibresProf(req) {


        return new Promise((resolve, reject) => {
            let perso_id = req.params.perso_id

            let requeteSQL = `SELECT * 
                FROM classes
                WHERE class_id NOT IN(SELECT liaison_personnel_classes.class_id
                    FROM  liaison_personnel_classes 
                    WHERE liaison_personnel_classes.perso_id = ?);`

            mysqlConnexion.query(requeteSQL, [perso_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelAfficherNotesUnEleve(req) {

        return new Promise((resolve, reject) => {
            let eleve_id = req.params.eleve_id
            //obligé de trier par classe car GROUP BY ne récupére pas certanis eleves
            let requeteSQL = `SELECT * FROM notes WHERE note_eleve_id = ?`
            mysqlConnexion.query(requeteSQL, [eleve_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelAjouterNote(req) {


        return new Promise((resolve, reject) => {
            let note_eleve_id = req.params.note_eleve_id
            let note_pourcent = req.params.note_pourcent
            let note_prof_id = req.params.note_prof_id
            let note_mat_id = req.params.note_mat_id
            let note_date_evaluation = req.params.note_date_evaluation
            let note_intitule = req.params.note_intitule
            let note_description = req.params.note_description

            let requeteSQL = "INSERT INTO notes (note_eleve_id, note_pourcent, note_prof_id, note_mat_id, note_date_evaluation, note_intitule, note_description) VALUES (?, ?, ?, ?, ?, ?, ?)"


            mysqlConnexion.query(requeteSQL, [note_eleve_id, note_pourcent, note_prof_id, note_mat_id, note_date_evaluation, note_intitule, note_description], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },



    async modelModifNote(req) {



        return new Promise((resolve, reject) => {
            

            let note_eleve_id = req.params.note_eleve_id
            let note_pourcent = req.params.note_pourcent
            let note_prof_id = req.params.note_prof_id
            let note_mat_id = req.params.note_mat_id
            let note_date_evaluation = req.params.note_date_evaluation
            let note_intitule = req.params.note_intitule
            let note_description = req.params.note_description
            let note_id = req.params.note_id


            let requeteSQL = 'UPDATE notes SET note_eleve_id = ?, note_pourcent = ?, note_prof_id = ?, note_mat_id = ?, note_date_evaluation = ?, note_intitule = ?, note_description = ?  WHERE note_id = ?'
            mysqlConnexion.query(requeteSQL, [note_eleve_id, note_pourcent, note_prof_id, note_mat_id, note_date_evaluation, note_intitule, note_description, note_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelSupprimerNote(req) {


        return new Promise((resolve, reject) => {

            let note_id = req.params.note_id

            let requeteSQL = "DELETE FROM notes WHERE note_id = ?;"


            mysqlConnexion.query(requeteSQL, [note_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
}

