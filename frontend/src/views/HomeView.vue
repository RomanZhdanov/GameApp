<template>
  <main>
    <games-explorer :pageSize="15" />
  </main>
</template>

<script lang="ts">
import GamesExplorer from '@/components/GamesExplorer.vue'

export default {
  components: {
    GamesExplorer
  }
}
</script>
