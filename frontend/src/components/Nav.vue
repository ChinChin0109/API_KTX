<template>
    <nav class="navbar navbar-expand-sm navbar-light fixed-top">
        <div class="container" >
            <router-link to="/" class="nav-link home">
                <font-awesome-icon icon="home" class="home" /> Home
            </router-link>
        </div>
        <div class="collapse navbar-collapse">
            <ul class="navbar-nav ml-auto" v-if="!user">
                <li class="nav-item m-1">
                    <router-link to="/login" class="nav-link" >
                        <font-awesome-icon icon="sign-in-alt" /> Login
                    </router-link>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Dropdown
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <router-link to="/diennuoc" class="nav-link" >
                        Dien Nuoc
                    </router-link>
                    <div class="dropdown-divider"></div>
                    <router-link to="/diennuoc" class="nav-link" >
                        Dien Nuoc
                    </router-link>
                    <div class="dropdown-divider"></div>
                    <router-link to="/diennuoc" class="nav-link" >
                        Dien Nuoc
                    </router-link>
                    <router-link to="/phonginfo" class="nav-link" >
                        PhongInfo
                    </router-link>
                    </div>
                </li>
                <li class="nav-item m-1">
                   <router-link to="/register" class="nav-link">
                        <font-awesome-icon icon="user-plus" /> Sign Up
                    </router-link>
                    
                </li>
            </ul>
            <ul class="navbar-nav ml-auto" v-if="user">
                <li class="nav-item m-1">
                    <router-link to="/department" class="nav-link" >
                        Department
                    </router-link>
                </li>
                <li class="nav-item m-1">
                    <router-link to="/employee" class="nav-link" >
                        Employee
                    </router-link>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Dropdown
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <router-link to="/diennuoc" class="nav-link" >
                        Điện nước
                    </router-link>
                    <div class="dropdown-divider"></div>
                    <router-link to="/phong" class="nav-link" >
                        Phòng
                    </router-link>
                    <div class="dropdown-divider"></div>
                    <router-link to="/diennuoc" class="nav-link" >
                        Vật tư
                    </router-link>
                    <div class="dropdown-divider"></div>
                    <router-link to="/phonginfo" class="nav-link" >
                        PhongInfo
                    </router-link>
                    </div>
                </li>
                <li class="nav-item m-1">
                    <a href="/" @click="logout()" class="nav-link" >Logout</a>
                </li>
            </ul>
        </div>
    </nav>
</template>

<script>
    export default {
        name: 'Nav',
        props: ['user'],
        methods:{
            logout(){
                localStorage.removeItem("token");
                localStorage.removeItem("UserId");
             //   this.$router.push("/");
            }
        }
    }
</script>

