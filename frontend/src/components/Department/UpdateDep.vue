<template>
  <div class="wrapper">
      <div class="inner">
          <form @submit.prevent="handleSubmit">
          <h3 class="title-department">Update</h3>

          <div class="form-group">
            <label>Department ID</label>
            <input
              type="text"
              class="form-control"
              v-model="dep.departmentId"
              disabled
              placeholder="Department ID"
            />
          </div>
          <div class="form-group">
            <label>Department Name</label>
            <input
              type="text"
              class="form-control"
              v-model="dep.departmentName"
              required
              placeholder="Department Name"
            />
          </div>
          <button class="btn btn-block btn-change">Update</button>
        </form>
      </div>
  </div>

</template>

<script>

const Token = localStorage.getItem('token');
import AxiosAuth from '@/utils/axios.utils';

export default {
  name: "UpdateDep",
  data() {
    return {
      dep:{},
      departmentId: 0,
      departmentName: "",
    };
  },
  created() {
    let uri = `https://localhost:44382/api/department/${this.$route.params.id}`;
    AxiosAuth.instance().get(uri).then((response) => {
        this.dep = response.data;
    });
  },
  methods: {
    handleSubmit() {
        var that = this;
       // console.log(this.departmentId);
          AxiosAuth.instance().put("department",
          {
            departmentId: this.dep.departmentId,
            departmentName:this.dep.departmentName
          },
          {
            headers: {
                'Authorization': `Bearer ${Token}`,
                'Accept': '*/*',
                'Content-Type': 'application/json; charset=utf-8'
              }
          })
          .then(
              (response)=>{
                  console.log(response.data);
                  alert("Update successfully");
                  that.$router.push("/department");
              },
              function () {
                alert("Update failed");
              }
          );
  
    },
  },
};
</script>