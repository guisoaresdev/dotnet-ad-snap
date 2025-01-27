import React, { useState } from "react";
import { createAdAPI } from "../../Services/AdService";
import { toast } from "react-toastify";
import "./Hero.css";

interface Props {}

const Hero = (props: Props) => {
  const [adType, setAdType] = useState<"product" | "service">("product");
  const [formData, setFormData] = useState({
    nome: "",
    dataPublicacao: "",
    valor: "",
    cidade: "",
    categoria: "",
    modelo: "",
    condicao: "",
    quantidade: "",
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async () => {
    try {
      const response = await createAdAPI(adType, formData);

      // Verifica se a resposta tem erro de validação
      if ('errors' in response) {
        // Exibir um toast para cada erro de validação
        for (const field in response.errors) {
          response.errors[field].forEach((errorMessage: string) => {
            toast.error(`${field}: ${errorMessage}`);
          });
        }
      } else if (response.status === 200 || response.status === 201) {
        toast.success("Anúncio cadastrado com sucesso!");
        setFormData({
          nome: "",
          dataPublicacao: "",
          valor: "",
          cidade: "",
          categoria: "",
          modelo: "",
          condicao: "",
          quantidade: "",
        });
      } else {
        toast.error("Erro ao cadastrar anúncio. Verifique os dados.");
      }
    } catch (error) {
      toast.error("Erro ao conectar com o servidor.");
    }
  };

  return (
    <section id="hero">
      <div className="container flex flex-col mx-auto p-8">
        <div className="flex flex-col space-y-10 mb-10">
          <h1 className="text-5xl font-bold text-center">Cadastre um Anúncio</h1>
          <div className="flex justify-center space-x-4">
            <button
              className={`py-2 px-4 text-xl font-bold ${adType === "product" ? "bg-lightGreen text-white" : "bg-gray-300"} rounded hover:opacity-70`}
              onClick={() => setAdType("product")}
            >
              Produto
            </button>
            <button
              className={`py-2 px-4 text-xl font-bold ${adType === "service" ? "bg-lightGreen text-white" : "bg-gray-300"} rounded hover:opacity-70`}
              onClick={() => setAdType("service")}
            >
              Serviço
            </button>
          </div>

          <form className="space-y-6">
            {/* Campos Comuns */}
            <div>
              <label className="block text-xl font-bold">Nome do Anúncio</label>
              <input
                type="text"
                name="nome"
                value={formData.nome}
                onChange={handleInputChange}
                className="w-full p-2 border rounded"
                placeholder="Digite o nome do anúncio"
                required
              />
            </div>
            <div>
              <label className="block text-xl font-bold">Data de Publicação</label>
              <input
                type="date"
                name="dataPublicacao"
                value={formData.dataPublicacao}
                onChange={handleInputChange}
                className="w-full p-2 border rounded"
                required
              />
            </div>
            <div>
              <label className="block text-xl font-bold">Valor</label>
              <input
                type="number"
                name="valor"
                value={formData.valor}
                onChange={handleInputChange}
                className="w-full p-2 border rounded"
                placeholder="Digite o valor"
                required
                min="1"
              />
            </div>
            <div>
              <label className="block text-xl font-bold">Cidade</label>
              <select
                name="cidade"
                value={formData.cidade}
                onChange={handleInputChange}
                className="w-full p-2 border rounded"
                required
              >
                <option value="">Selecione</option>
                <option value="SaoPaulo">São Paulo</option>
                <option value="RioDeJaneiro">Rio de Janeiro</option>
                <option value="BeloHorizonte">Belo Horizonte</option>
              </select>
            </div>

            {/* Campos Específicos para Produto */}
            {adType === "product" && (
              <>
                <div>
                  <label className="block text-xl font-bold">Categoria</label>
                  <select
                    name="categoria"
                    value={formData.categoria}
                    onChange={handleInputChange}
                    className="w-full p-2 border rounded"
                    required
                  >
                    <option value="">Selecione</option>
                    <option value="Eletronicos">Eletrônicos</option>
                    <option value="Vestuario">Vestuário</option>
                    <option value="Moveis">Móveis</option>
                  </select>
                </div>
                <div>
                  <label className="block text-xl font-bold">Modelo</label>
                  <select
                    name="modelo"
                    value={formData.modelo}
                    onChange={handleInputChange}
                    className="w-full p-2 border rounded"
                    required
                  >
                    <option value="">Selecione</option>
                    <option value="SmartTV">Smart TV UltraView 4K 55"</option>
                    <option value="Jaqueta">Jaqueta Puffer Windproof</option>
                    <option value="MesaJantar">Mesa de Jantar Madeira Prime 6 Lugares</option>
                  </select>
                </div>
                <div>
                  <label className="block text-xl font-bold">Condição</label>
                  <select
                    name="condicao"
                    value={formData.condicao}
                    onChange={handleInputChange}
                    className="w-full p-2 border rounded"
                    required
                  >
                    <option value="">Selecione</option>
                    <option value="Novo">Novo</option>
                    <option value="Usado">Usado</option>
                    <option value="Seminovo">Seminovo</option>
                  </select>
                </div>
                <div>
                  <label className="block text-xl font-bold">Quantidade</label>
                  <input
                    type="number"
                    name="quantidade"
                    value={formData.quantidade}
                    onChange={handleInputChange}
                    className="w-full p-2 border rounded"
                    placeholder="Digite a quantidade"
                    required
                    min="1"
                  />
                </div>
              </>
            )}

            {/* Botões */}
            <div className="flex justify-end space-x-4">
              <button
                type="button"
                onClick={() => setFormData({ nome: "", dataPublicacao: "", valor: "", cidade: "", categoria: "", modelo: "", condicao: "", quantidade: "" })}
                className="py-2 px-4 bg-gray-300 rounded hover:opacity-70"
              >
                Limpar
              </button>
              <button
                type="button"
                onClick={handleSubmit}
                className="py-2 px-4 bg-lightGreen text-white rounded hover:opacity-70"
              >
                Confirmar
              </button>
            </div>
          </form>
        </div>
      </div>
    </section>
  );
};

export default Hero;
