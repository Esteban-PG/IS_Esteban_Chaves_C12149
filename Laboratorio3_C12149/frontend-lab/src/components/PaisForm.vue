<template>
    <div>
        <h1>Formulario para crear un pa�s</h1>

        <div class="d-flex justify-content-center align-items-center vh-100">
            <div class="card p-4 shadow" style="max-width: 400px; width: 100%;">
                <h3 class="text-center">Formulario de creaci�n de pa�ses</h3>

                <form @submit.prevent="guardarPais">
                    <div class="form-group">
                        <label for="nombre">Nombre:</label>
                        <input v-model="datosFormulario.nombre"
                               type="text"
                               id="nombre"
                               class="form-control"
                               required />
                    </div>

                    <div class="form-group">
                        <label for="continente">Continente:</label>
                        <select v-model="datosFormulario.continente"
                                id="continente"
                                class="form-control"
                                required>
                            <option value="" disabled>Seleccione un continente</option>
                            <option>�frica</option>
                            <option>Asia</option>
                            <option>Europa</option>
                            <option>Am�rica</option>
                            <option>Ocean�a</option>
                            <option>Ant�rtida</option>
                        </select>
                    </div>

                    <div class="form-group">
                        <label for="idioma">Idioma:</label>
                        <input v-model="datosFormulario.idioma"
                               type="text"
                               id="idioma"
                               class="form-control"
                               required />
                    </div>

                    <div>
                        <button type="submit" class="btn btn-success btn-block">
                            Guardar
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>


<script>
    import axios from "axios";
    export default {
        data() {
            return {
                datosFormulario: {
                    nombre: "",
                    continente: "",
                    idioma: ""
                }
            };
        },

            methods: {
                guardarPais() {
                    console.log("Datos a guardar: ", this.datosFormulario);
                    axios.post("https://localhost:7067/api/Paises", {
                        nombre: this.datosFormulario.nombre,
                        continente: this.datosFormulario.continente,
                        idioma: this.datosFormulario.idioma,
                    }).then(function (response)
                    {
                        console.log(response); 
                        window.location.href = "/";
                    })
                        .catch(function (error) {
                            console.error(error);
                        });
                
                }
            }
    };
</script>


<style></style>