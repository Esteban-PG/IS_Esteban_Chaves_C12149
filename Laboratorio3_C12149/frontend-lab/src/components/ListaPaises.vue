<template>
    <div class="container mt-5">
        <h1 class="display-4 text-center">Lista de paises</h1>
        <div class = "row justify-content-end">
            <div class="col-2">
                <a href="/pais">
                    <button type=" button" class=" btn btn-outline-secondary float-right">
                        Agregar pais
                    </button>
                </a>

            </div>
        </div> 
    </div>

    <div class="container mt-5">
 <h1 class="display-4 text-center">Lista de países</h1>
 <table
 class="table is-bordered is-striped is-narrow is-hoverable
is-fullwidth"
 >
 <thead>
 <tr>
 <th>Nombre</th>
 <th>Continente</th>
 <th>Idioma</th>
 <th>Acciones</th>
 </tr>
 </thead>
 <tbody>
    <tr v-for="(paises, index) of paises" :key="index">
        <td>{{ paises.nombre }}</td>
        <td>{{ paises.continente }}</td>
        <td>{{ paises.idioma }}</td>
        <td>
            <button class="btn btn-secondary btn-sm">Editar</button>
            <button class="btn btn-danger btn-sm" @click="eliminarPais(index)">Eliminar</button>
        </td>
    </tr>
 </tbody>
 </table>
 </div>

</template>

<script>
    import axios from "axios";
    export default {
        data() {
            return {
                paises: [
                    { nombre: "Costa Rica", continente: "América", Idioma: "Español" },
                    { nombre: "Japón", continente: "Asia", Idioma: "Japonés" },
                    { nombre: "Corea del Sur", continente: "Asia", Idioma: "Coreano" },
                    { nombre: "Italia", continente: "Europa", Idioma: "Italiano" },
                    { nombre: "Alemania", continente: "Europa", Idioma: "Alemán" },
                ],
            };
        },
        methods: {
            eliminarPais(index) {
                this.paises.splice(index, 1);
            },
            obtenerTareas() {
                axios.get("https://localhost:7067/api/Paises").then(
                    (response) => {
                        this.paises = response.data;
                    });
            },

        },
        created: function () {
            this.obtenerTareas();
        },

    };
</script>

<style lang="scss" scoped>

</style>