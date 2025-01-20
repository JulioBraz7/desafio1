import React, { useState, useEffect } from "react";
import ProjectList from "./components/ProjectList";
import ProjectForm from "./components/ProjectForm";
import { getProjects, createProject, updateProject, deleteProject } from "./services/api";

function App() {
  const [projects, setProjects] = useState([]);
  const [editProject, setEditProject] = useState(null);

  useEffect(() => {
    fetchProjects();
  }, []);

  const fetchProjects = async () => {
    try {
      const response = await getProjects();
      setProjects(response.data);
    } catch (error) {
      console.error("Erro ao buscar projetos:", error);
    }
  };

  const handleAddProject = async (project) => {
    try {
      if (editProject) {
        await updateProject(editProject.id, project);
      } else {
        await createProject(project);
      }
      fetchProjects();
      setEditProject(null);
    } catch (error) {
      console.error("Erro ao salvar projeto:", error);
    }
  };

  const handleDeleteProject = async (id) => {
    try {
      await deleteProject(id);
      fetchProjects();
    } catch (error) {
      console.error("Erro ao deletar projeto:", error);
    }
  };

  return (
    <div>
      <h1>Gerenciamento de Projetos</h1>
      <ProjectForm onSubmit={handleAddProject} editProject={editProject} />
      <ProjectList projects={projects} onEdit={setEditProject} onDelete={handleDeleteProject} />
    </div>
  );
}

export default App;

