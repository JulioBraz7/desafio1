import React, { useState, useEffect } from "react";

function ProjectForm({ onSubmit, editProject }) {
  const [project, setProject] = useState({
    name: "",
    description: "",
    deadline: "",
  });

  useEffect(() => {
    if (editProject) setProject(editProject);
  }, [editProject]);

  const handleChange = (e) => {
    setProject({ ...project, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(project);
    setProject({ name: "", description: "", deadline: "" });
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        name="name"
        placeholder="Nome do Projeto"
        value={project.name}
        onChange={handleChange}
        required
      />
      <textarea
        name="description"
        placeholder="Descrição"
        value={project.description}
        onChange={handleChange}
        required
      />
      <input
        type="date"
        name="deadline"
        value={project.deadline}
        onChange={handleChange}
        required
      />
      <button type="submit">
        {editProject ? "Atualizar Projeto" : "Adicionar Projeto"}
      </button>
    </form>
  );
}

export default ProjectForm;
