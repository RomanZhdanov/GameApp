<template>
  <form class="d-flex" role="search" @submit.prevent="submitSearch">
    <input
      class="form-control me-2"
      v-model="searchInput"
      type="search"
      placeholder="Search"
      aria-label="Search"
    />
    <button class="btn btn-outline-success" type="submit">Search</button>
  </form>
  <div v-if="isLoading">Loading...</div>
  <div v-else-if="pageResult">
    <ul>
      <li v-for="game in pageResult.items" :key="game.id">
        {{ game.title }}
      </li>
    </ul>
    <base-pagination
      :currentPage="page"
      :totalPages="pageResult.totalPages"
      :hasNext="pageResult.hasNextPage"
      :hasPrevious="pageResult.hasPreviousPage"
      @page-changed="selectPage"
    />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { gamesService } from '@/services/'
import type { GamesPageResult } from '@/types/gameTypes'
import BasePagination from '@/components/ui/BasePagination.vue'

export default defineComponent({
  components: {
    BasePagination
  },
  props: {
    pageSize: {
      type: Number,
      required: false,
      default: 10
    }
  },
  data() {
    return {
      searchInput: '',
      pageResult: {} as GamesPageResult,
      page: 1 as number,
      isLoading: false
    }
  },
  methods: {
    async loadGamesPage(): Promise<void> {
      this.isLoading = true
      const { data } = await gamesService.getPage(this.page, this.pageSize)
      this.pageResult = data
      this.isLoading = false
    },
    async searchGame() {
      this.isLoading = true
      const { data } = await gamesService.search(this.searchInput, this.page, this.pageSize)
      this.pageResult = data
      this.isLoading = false
    },
    submitSearch() {
      if (this.searchInput) {
        this.page = 1
        this.searchGame()
      }
    },
    selectPage(page: number) {
      this.page = page
      if (this.searchInput) {
        this.searchGame()
      } else {
        this.loadGamesPage()
      }
    }
  },
  created() {
    this.loadGamesPage()
  }
})
</script>
