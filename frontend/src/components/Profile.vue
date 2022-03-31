<template>
  <div class="wrapper">
      <div class="inner">
         <h3 v-if="user">Hi, {{user.firstName}}</h3>
         <h3 v-if="!user">Nothing</h3>
      </div>
  </div>
</template>

<script>
export default {
  name: "Profile",
  props:['user']
}
</script>

<style>

</style>
