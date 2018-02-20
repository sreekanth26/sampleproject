﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Threading.Tasks;

using Moq;

namespace Microsoft.VisualStudio.ProjectSystem.Debug
{
    internal class IActiveConfiguredProjectsProviderFactory
    {
        private Mock<IActiveConfiguredProjectsProvider> _mock;
        public IActiveConfiguredProjectsProviderFactory(MockBehavior mockBehavior = MockBehavior.Strict)
        {
            _mock = new Mock<IActiveConfiguredProjectsProvider>(mockBehavior);
        }

        public IActiveConfiguredProjectsProvider Object => _mock.Object;

        public void Verify()
        {
            _mock.Verify();
        }

        public IActiveConfiguredProjectsProviderFactory ImplementGetActiveConfiguredProjectsMapAsync(ImmutableDictionary<string, ConfiguredProject> configuredProjects) 
        {
#pragma warning disable CS0618 // Type or member is obsolete
            _mock.Setup(x => x.GetActiveConfiguredProjectsMapAsync())
#pragma warning restore CS0618 // Type or member is obsolete
                              .Returns(Task.FromResult(configuredProjects));
            return this;
        }

        public IActiveConfiguredProjectsProviderFactory ImplementGetActiveConfiguredProjectsAsync(ActiveConfiguredObjects<ConfiguredProject> configuredProjects) 
        {
            _mock.Setup(x => x.GetActiveConfiguredProjectsAsync())
                              .Returns(Task.FromResult(configuredProjects));
            return this;
        }

        public IActiveConfiguredProjectsProviderFactory ImplementGetProjectFrameworksAsync(ActiveConfiguredObjects<ProjectConfiguration> projectConfigurations) 
        {
            _mock.Setup(x => x.GetActiveProjectConfigurationsAsync())
                              .Returns(Task.FromResult(projectConfigurations));
            return this;
        }
    }
}
