﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Extensions.Models
{
    public class TokenWalletFilterList : IEnumerable<TokenWalletAccount>
    {

        private IList<TokenWalletAccount> _list;

        public TokenWalletFilterList(IEnumerable<TokenWalletAccount> accounts)
        {
            _list = new List<TokenWalletAccount>(accounts);
        }

        public IEnumerator<TokenWalletAccount> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public TokenWalletFilterList WithSymbol(string symbol)
        {
            return new TokenWalletFilterList(_list.Where(x => x.Symbol == symbol));
        }

        public TokenWalletFilterList WithMint(string mint)
        {
            return new TokenWalletFilterList(_list.Where(x => x.TokenMint == mint));
        }

        public TokenWalletFilterList WithAtLeast(decimal minimumBalance)
        {
            return new TokenWalletFilterList(_list.Where(x => x.BalanceDecimal >= minimumBalance));
        }

        public TokenWalletFilterList WithAtLeast(ulong minimumBalance)
        {
            return new TokenWalletFilterList(_list.Where(x => x.BalanceRaw == minimumBalance));
        }

        public TokenWalletFilterList WhichAreAssociatedTokenAccounts()
        {
            return new TokenWalletFilterList(_list.Where(x => x.IsAssociatedTokenAccount));
        }

    }
}
