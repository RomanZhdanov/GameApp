<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import TheHeader from '@/components/layout/TheHeader.vue'
</script>

<template>
  <the-header />
  <div class="container">
    <RouterView />
  </div>
</template>
