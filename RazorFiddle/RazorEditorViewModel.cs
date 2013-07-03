using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RazorEngine.Templating;

namespace RazorFiddle
{
    internal class RazorEditorViewModel : ViewModelBase
    {
        #region Fields

        private string _razorScript;
        private string _parsedScript;

        private RelayCommand _onCompileRequested;

        #endregion

        public RazorEditorViewModel()
        {
            _razorScript = string.Empty;
            _parsedScript = string.Empty;
        }

        public string RazorScript
        {
            get { return _razorScript; }
            set
            {
                if (value != _razorScript)
                {
                    _razorScript = value;
                    RaisePropertyChanged(() => RazorScript);
                }
            }
        }

        public string ParsedScript
        {
            get { return _parsedScript; }
            set {
                if (value != _parsedScript)
                {
                    _parsedScript = value;
                    RaisePropertyChanged(() => ParsedScript);
                }
            }
        }

        public RelayCommand CompileScriptAction
        {
            get
            {
                if (null == _onCompileRequested)
                {
                    _onCompileRequested = new RelayCommand(
                        () =>
                            {
                                try
                                {
                                    ParsedScript = RazorCompiler.ParseScript(RazorScript);
                                }
                                catch (TemplateParsingException pe)
                                {
                                    ParsedScript = pe.Message;
                                }
                                catch (TemplateCompilationException tc)
                                {
                                    ParsedScript = string.Join(Environment.NewLine, tc.Errors);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(
                                        string.Format("An unknown exception ({0}) occurred with the message '{1}'",
                                                      e.GetType().FullName, e.Message));
                                }
                            });
                }

                    return _onCompileRequested;
                }
        }
    }
}
