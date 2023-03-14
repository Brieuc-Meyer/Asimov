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

    async modelAfficherElevesUnProf() {


        return new Promise((resolve, reject) => {

            let requeteSQL = `SELECT * 
            FROM  eleves, liaison_personnel_classes, classes 
            WHERE liaison_personnel_classes.perso_id = ? 
            AND eleves.eleve_class_grade = classes.class_grade 
            AND liaison_personnel_classes.class_grade = eleves.eleve_class_grade 
            ORDER BY classes 
            ORDER BY eleves_nom;`

            mysqlConnexion.query(requeteSQL, (err, data) => {

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

            let nom = req.body.nom
            let identifiant = req.body.identifiant
            let mdp = req.body.mdp
            let classe = req.body.classe

            let requeteSQL = "INSERT INTO eleves (eleve_nom, eleve_identigfiant, eleve_mdp, eleve_class_grade) VALUES (?, ?, ?, ?)"


            mysqlConnexion.query(requeteSQL, [nom, identifiant, mdp, classe], (err, data) => {

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

            let id = req.params.id

            let requeteSQL = "DELETE FROM eleves WHERE eleve_id = ?;"


            mysqlConnexion.query(requeteSQL, [id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },


    async modelafficherModifMedicament(req) {

        return new Promise((resolve, reject) => {

            let id = req.params.id

            let requeteSQL = 'SELECT * FROM eleves WHERE eleve_id = ?'
            mysqlConnexion.query(requeteSQL, [id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },




    async modelmodifMedicament(req) {



        return new Promise((resolve, reject) => {

            let id = req.body.id
            let nom = req.body.nom
            let identifiant = req.body.identifiant
            let mdp = req.body.mdp
            let classe = req.body.classe

            let requeteSQL = 'UPDATE eleves SET eleve_nom = ?, eleve_identifiant = ?, eleve_mdp = ?, eleve_class_grade = ?  WHERE eleve_id = ?'
            mysqlConnexion.query(requeteSQL, [nom, identifiant, mdp, classe, id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },



}

