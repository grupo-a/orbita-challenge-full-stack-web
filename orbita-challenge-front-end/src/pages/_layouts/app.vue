<template>
  <div>
    <v-navigation-drawer v-model="isDrawerOpen">
      <div class="text-3xl font-bold underline pl-10 pt-4 pb-5 border-b-2">
        <v-img
          cover
          src="https://maisaedu.com.br/hubfs/site-grupo-a/logo-mais-a-educacao.svg"
          width="75%"
        ></v-img>
      </div>

      <v-list
        class="mx-auto p-0"
        max-width="256"
        color="#2D2C2C"
      >
        <v-list-item
          prepend-icon="mdi-account"
          title="Alunos"
          link
          to="/students"
        />
      </v-list>
    </v-navigation-drawer>

    <v-app-bar flat class="border-b">
      <v-app-bar-nav-icon @click="isDrawerOpen = !isDrawerOpen"></v-app-bar-nav-icon>
      <v-app-bar-title class="text-black tracking-tight">
        Módulo Acadêmico
      </v-app-bar-title>

      <template #append>
        <v-btn icon class="mr-2">
          <v-badge dot color="info">
            <v-icon icon="mdi-bell-outline"></v-icon>
          </v-badge>
        </v-btn>
      </template>
    </v-app-bar>

    <router-view />
  </div>
</template>

<script lang="ts" setup>
  import { ref } from 'vue'

  const isDrawerOpen = ref(true)
</script>