app.controller("AddBoat", function($scope){

	//gere l'etat du bouton de validation de la creation du Bateau
	function SetBtnSubmit(etat){
		if (etat) {
			document.getElementById("BtnSubmit").removeAttribute("disabled");
		}else{
			document.getElementById("BtnSubmit").setAttribute("disabled", "disabled");
		}
	}

	//gere l'etat du bouton de validation des choix des Personnes pour le Role dans le panel
	function setBtnSavRolePanel(etat){
		if (etat) {
			document.getElementById("btnSavRolePanel").removeAttribute("disabled");
		}else{
			document.getElementById("btnSavRolePanel").setAttribute("disabled", "disabled");
		}
	}

	//Permet de retourner le nb de personne minimal et maximal pour le role avec comme id l'IdRole 
	function getMinMaxRole(idRole){
		var minmax = {"min" : -1, "max" : -1};
		var listTypes = document.getElementsByTagName("option");
		for (var i = 0; i < listTypes.length; i++) {
			if (listTypes[i].getAttribute("selected") == "selected") {
				var listRoleType = listTypes[i].getAttribute("inforole");
				var regexTest = idRole + "=([0-9]+)~([0-9]+)";
				var matchList = listRoleType.match(regexTest);
				minmax["min"] = matchList[1];
				minmax["max"] = matchList[2];
			}
			
		}
		return minmax;
	}




	SetBtnSubmit(false);

	var listRoles = document.getElementsByClassName("btn-add-personne-bateau");
	// Pour chaque bouton d'ajout de Personne pour un Role
	for (var i = 0; i < listRoles.length; i++) {
		//Ajout de l'évènement de l'affichage des Personnes disponible pour le Role
		listRoles[i].addEventListener("click", function($this){
			setBtnSavRolePanel(false);
			window.idRole = $this.target.getAttribute("identifier");
			idRole = window.idRole;
			if (document.getElementById("panel").getAttribute("hidden") == "hidden") {
				document.getElementById("panel").removeAttribute("hidden");
				var regexTest = idRole + ";";
				var minmax = getMinMaxRole(idRole);
				document.getElementById("nb_Min_Place").innerHTML = minmax["min"];
				document.getElementById("nb_Max_Place").innerHTML = minmax["max"];
				var listPersonnes = document.getElementsByClassName("personne");
				//pour chaque Personne
				for (var i = 0; i < listPersonnes.length; i++) {
					var personne_role= listPersonnes[i].getAttribute("role");
					//Si il ne possede pas le Role, on cache la Personne
					if (personne_role.search(regexTest) == -1) {
						listPersonnes[i].style.display = "none";
					//Sinon on l'affiche
					}else{
						listPersonnes[i].style.display = "inline-block";
					}
				}
			}
		});
	}

		//bouton de fermeture du panel
		document.getElementById("btnClosePanel").addEventListener("click", function(){
			document.getElementById("panel").setAttribute("hidden", "hidden");
		});

		var listTypes = document.getElementsByTagName("option");

		//gere la selection dynamique du type de bateau selectionné
		for (var i = 0; i < listTypes.length; i++) {
			listTypes[i].addEventListener("click", function($this){
				if ($this.target.value != "null") {
					var listTypes = document.getElementsByTagName("option");
					for (var i = 0; i < listTypes.length; i++) {
						if(listTypes[i].value == "null"){
							listTypes[i].parentNode.removeChild(listTypes[i]);  
							break;
						}
						listTypes[i].removeAttribute("selected");
					}
					$this.target.setAttribute("selected", "selected");
				}
			});
		}

		var listPersonne = document.getElementById("panel").getElementsByClassName("personne");
		var nbPersonne = 0;
		for (var i = listPersonne.length - 1; i >= 0; i--) {
			listPersonne[i].addEventListener("click", function($this){
				var idTarget = $this.target.id;
				//deselectionne le Role  
				if ($this.target.hasAttribute("selected")) {
					$this.target.removeAttribute("selected");
					var removedInput = document.getElementById(idTarget + "Personne");
					document.getElementsByTagName("form")[0].childNodes[1].removeChild(removedInput);
					var listPersonnesSelected = document.getElementsByTagName("form")[0].childNodes[1].getElementsByTagName("input");
					nbPersonne--;
					if (nbPersonne == 0) {
						SetBtnSubmit(false);
					}else{
						for (var i = 0; i < listPersonnesSelected.length; i++) {
							listPersonnesSelected[i].setAttribute("name", "personnes[" + i + "]");
						}
					}
				////selectionne le Role 
				} else {
				//input créé
				/*<input hidden="hidden" id="IdTargetPersonne" name="personnes[nbPersonne]" value="IdRole;IdTarget">*/
				var idRole = window.idRole;
				var input = document.createElement("input");
				input.setAttribute("hidden", "hidden");
				input.setAttribute("name", "personnes[" + (nbPersonne++) +"]");
				input.setAttribute("id", idTarget + "Personne");
				input.setAttribute("value", (idRole) + ";" + idTarget);
				document.getElementsByTagName("form")[0].childNodes[1].appendChild(input);
				$this.target.setAttribute("selected", "selected");
				SetBtnSubmit(true);
				}
			});
		}


	});