/* Adicionar o focus no textbox assim que a página for carregada */
window.onload = function PageLoadFocus(){
    txtLogin.Focus();
};

/* Função para abrir o pop-up de recuperação de senha */
function OpenPopUpRecuperarSenha(){
    txtLogin.SetText("");
    txtSenha.SetText("");
    popRecuperarSenha.Show();
    txtLoginRecuperacaoSenha.Focus();
}

/* Função para fechar o pop-up de recuperação de senha */
function ClosePopUpRecuperarSenha(){
    txtLoginRecuperacaoSenha.SetText("");
    txtCPFRecuperacaoSenha.SetText("");
    txtEmailRecuperacaoSenha.SetText("");
    txtLoginRecuperacaoSenha.SetIsValid(true);
    txtCPFRecuperacaoSenha.SetIsValid(true);
    txtEmailRecuperacaoSenha.SetIsValid(true);
    txtLogin.Focus();
}
       
/* Função que efetua a validação dos dados e chama o callback para recuperar a senha do usuário */            
function CallbackRecuperarSenha(){ 
    if(txtLoginRecuperacaoSenha.GetIsValid() && txtEmailRecuperacaoSenha.GetIsValid() && txtCPFRecuperacaoSenha.GetIsValid()){              
        cbRecuperarSenhaSistema.PerformCallback(txtLoginRecuperacaoSenha.GetText() + "#" + txtEmailRecuperacaoSenha.GetText() + "#" + txtCPFRecuperacaoSenha.GetText());                
    }
    else {
        alert("Atenção: Verifique os dados de recuperação informados e tente novamente!");
    }
}